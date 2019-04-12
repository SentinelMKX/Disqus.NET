namespace Disqus.NET.Models
{
    public class DisqusAuthor : DisqusUserBase
    {
        public static implicit operator DisqusAuthor(string str)
        {
            int.TryParse(str, out var id);

            return new DisqusAuthor
            {
                Id = id
            };
        }
    }
}