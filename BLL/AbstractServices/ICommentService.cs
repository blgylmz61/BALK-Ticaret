using BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AbstractServices
{
    public interface ICommentService
    {
        Task CreateComment(CommentDto commentDto);
        Task DeleteComment(int commentId);
        Task UpdateComment(CommentDto commentDto);
        Task<CommentDto> GetCommentById(int commentId);
        Task<List<CommentDto>> GetAllComment();
    }
}
