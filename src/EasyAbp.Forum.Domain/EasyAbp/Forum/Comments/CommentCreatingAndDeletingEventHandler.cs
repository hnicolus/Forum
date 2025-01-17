﻿using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events;
using Volo.Abp.EventBus;
using Volo.Abp.Uow;

namespace EasyAbp.Forum.Comments
{
    [UnitOfWork(true)]
    public class CommentCreatingAndDeletingEventHandler :
        ILocalEventHandler<EntityCreatingEventData<Comment>>,
        ILocalEventHandler<EntityDeletingEventData<Comment>>,
        ITransientDependency
    {
        private readonly ICommentRepository _commentRepository;

        public CommentCreatingAndDeletingEventHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public virtual async Task HandleEventAsync(EntityCreatingEventData<Comment> eventData)
        {
            if (!eventData.Entity.ParentId.HasValue)
            {
                return;
            }

            var parent = await _commentRepository.GetAsync(eventData.Entity.ParentId.Value);
            
            parent.SetChildrenCount(1 + parent.ChildrenCount);

            await _commentRepository.UpdateAsync(parent, true);
        }

        public virtual async Task HandleEventAsync(EntityDeletingEventData<Comment> eventData)
        {
            if (!eventData.Entity.ParentId.HasValue)
            {
                return;
            }

            var parent = await _commentRepository.GetAsync(eventData.Entity.ParentId.Value);
            
            parent.SetChildrenCount(parent.ChildrenCount - 1);

            await _commentRepository.UpdateAsync(parent, true);
        }
    }
}