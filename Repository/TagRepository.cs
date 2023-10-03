using System.Collections;
using appflow.Contexts;
using appflow.DTOs;
using appflow.Repository.interfaces;
using appflow.Repository.ResponseModels;
using Microsoft.AspNetCore.Server.IIS.Core;


namespace appflow.Repository
{

    public class TagRepository : ITagRepository
    {

        public readonly ApplicationDbContext _db;
        public TagRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Tag> CreateUserDefaultTags(string userId)
        {
            List<Tag> tags = new List<Tag>(){
                new Tag { Text = "Vermelho", Color = "#FF0000", ApplicationUserId = userId },
                new Tag { Text = "Verde", Color = "#00FF00", ApplicationUserId = userId },
                new Tag { Text = "Azul", Color = "#0000FF", ApplicationUserId = userId },
                new Tag { Text = "Ciano", Color = "#00FFFF", ApplicationUserId = userId },
                new Tag { Text = "Magenta", Color = "#FF00FF", ApplicationUserId = userId },
                new Tag { Text = "Amarelo", Color = "#FFFF00", ApplicationUserId = userId },
            };

            _db.Tags.AddRange(tags);

            _db.SaveChangesAsync();
            return tags;
        }

        public IEnumerable<TagResponse> GetUserTags(string user)
        {

            return _db.Tags.Where(tag => tag.ApplicationUser.Id == user).Select(o => new TagResponse(o.TagId, o.Text, o.Color)).ToList();

        }



        public void Update(int tagId, TagDto body)
        {
            // _db.Tags.SetV(tag);
            var tagObj = _db.Tags.Find(tagId);

            if (tagObj is not null)
            {
                _db.Entry(tagObj).CurrentValues.SetValues(body);
                _db.SaveChanges();
            }

        }
    }
}