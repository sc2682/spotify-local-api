A very simple and small library that allows .NET developers to get track information, (un)pause spotify, play tracks, get cover art and more!

# Example #
```
SpotifyAPI API = new SpotifyAPI(SpotifyAPI.GetOAuth(), "jariz-example.spotilocal.com");
Responses.CFID cfid = API.CFID;
Responses.Status Current_Status = API.Status;

if (Current_Status.track != null)
    Console.WriteLine(string.Format("You're listening to {0} - {1} from the album '{2}'",
        Current_Status.track.track_resource.name, 
        Current_Status.track.artist_resource.name, 
        Current_Status.track.album_resource.name));
else
    Console.WriteLine("You're not listening to any songs");

Thread.Sleep(1000);
//Pause playback
Current_Status = API.Pause;

Thread.Sleep(1000);
//Resume playback
Current_Status = API.Resume;

Thread.Sleep(1000);
//Play 'Evil Boy'
API.URI = "spotify:track:3wcekXbEsDFv9OfyJe1q5d";
Current_Status = API.Play;

Thread.Sleep(1000);
//Get current album art and open it in browser
string art = API.getArt(Current_Status.track.album_resource.uri); //get current art url
Process.Start(art); //open url in browser
```

# Dependencies #
Newtonsoft.JSON (http://json.codeplex.com/)

_Just add it as a reference to your project and you should be fine_

# Features #
  * Pause
  * Resume
  * Get very detailed track info
  * Play Spotify URI's
  * Get OAuth key from Spotify website

# How does it work? #
Spotify has a process running called SpotifyWebHelper.exe on port 4380 which is normally  used for the play buttons on Facebook and the embed players.
Most people don't know this but there's a real API running on that port, Providing several functions that can be used in several types of responses including JSON and XML.
They've added several methods to make sure that stuff only gets ran from the webbrowsers such as Origin and Referer headers checking and OAuth keys, but both are really easy to bypass. (you won't have to worry about this)

# Why are there no Skip and Previous functions? #
The embed player only uses the play function with the URI of the next song.
There might be a API call for this but I got no idea what it's name is

# Soon to be added #
  * Playlist support (recieve playlist information)
  * ????

# Suggestions #
Do you know any more functions that SpotifyWebHelper provides but currently aren't included in this library? Create a new Issue at the 'Issues' and I will look into it!