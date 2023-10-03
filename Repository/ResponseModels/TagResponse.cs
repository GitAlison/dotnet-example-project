
namespace appflow.Repository.ResponseModels;

public class TagResponse
{

    public int TagId { get; set; }

    public string Text { get; set; }
    public string Color { get; set; }

    public TagResponse(int TagId, string Text, string Color)
    {
        this.TagId = TagId;
        this.Text = Text;
        this.Color = Color;
    }


}
