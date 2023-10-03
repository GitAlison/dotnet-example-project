using appflow.DTOs;
using appflow.Repository.ResponseModels;

namespace appflow.Repository.interfaces
{
    public interface ITagRepository
    {
        IEnumerable<Tag> CreateUserDefaultTags(string userId);
        IEnumerable<TagResponse> GetUserTags(string userId);
        void Update(int tagId,TagDto body);
    }
}