using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JariZ;
using System.Threading;
using System.Diagnostics;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SpotifyLocalAPI demonstration");
            Console.WriteLine("By JariZ.nl 2012");
            Console.WriteLine("Warning: This demo requires you to have Spotify open and running!");
            Console.WriteLine();
            Console.WriteLine("Authenticating...");

            try
            {
                SpotifyAPI API = new SpotifyAPI(SpotifyAPI.GetOAuth(), "jariz-example.spotilocal.com");
                Responses.CFID cfid = API.CFID; //It's required to get the contents of API.CFID before doing anything, even if you're not intending to do anything with the CFID
                
                Responses.Status Current_Status = API.Status;

                if (Current_Status.track != null)
                    Console.WriteLine(string.Format("You're listening to {0} - {1} from the album '{2}'", Current_Status.track.track_resource.name, Current_Status.track.artist_resource.name, Current_Status.track.album_resource.name));
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

                Console.WriteLine();
                Console.WriteLine("Tests complete.");
            }
            catch (Exception z)
            {
                Console.WriteLine("Unexpected error:\r\n" + z.ToString());
            }
            Thread.Sleep(-1);
        }
    }
}
