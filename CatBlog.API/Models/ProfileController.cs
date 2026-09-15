using System.IO;
using System.Text.Json;

namespace CatBlog.API.Models;

public class ProfileController
{
    private static ProfileController _controller;
    private const string _profilePath = "../Data/Json/profile.json";

    public Profile Profile
    {
        get
        {
            var profileJson = File.ReadAllText(_profilePath);

            return JsonSerializer.Deserialize<Profile>(profileJson);
        }
    }

    private ProfileController() { }

    public static ProfileController GetInstance()
    {
        return _controller == null ? _controller = new ProfileController() : _controller;
    }

    public void UpdateProfile(Profile newProfile)
    {
        var profileJson = JsonSerializer.Serialize(newProfile);

        File.WriteAllText(_profilePath, profileJson);
    }
}
