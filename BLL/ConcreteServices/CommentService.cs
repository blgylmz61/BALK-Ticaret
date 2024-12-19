using AutoMapper;
using BLL.AbstractServices;
using BLL.Dtos;
using BLL.Helpers;
using DAL.AbstractRepository;
using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ConcreteServices
{
    public class CommentService : ICommentService
    {
        private readonly IRepository<Comment> _commentRepository;
        private readonly IMapper _mapper;
        public CommentService(IRepository<Comment> commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
        public async Task CreateComment(CommentDto commentDto)
        {
            await _commentRepository.AddAsync((_mapper.Map<Comment>(commentDto)));
        }

        public async Task DeleteComment(int commentId)
        {
            await _commentRepository.DeleteAsync(commentId);
        }

        public async Task<List<CommentDto>> GetAllComment()
        {
            var allComment=await _commentRepository.GetAllAsync();
            return (_mapper.Map<List<CommentDto>>(allComment));

        }

        public async Task<CommentDto> GetCommentById(int commentId)
        {
            var comment = await _commentRepository.GetByIdAsync(commentId);
            return (_mapper.Map<CommentDto>(comment));
        }

        public async Task UpdateComment(CommentDto commentDto)
        {
            var comment = await _commentRepository.GetByIdAsync(commentDto.Id);
            comment.Scor = commentDto.Scor;
            comment.CommentDate = commentDto.CommentDate;
            comment.Description = commentDto.Description;

            var updateComment = _mapper.Map<Comment>(comment);
            await _commentRepository.UpdateAsync(updateComment);
        }
    }
}
