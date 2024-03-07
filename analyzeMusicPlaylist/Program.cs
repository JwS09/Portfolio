namespace analyzeMusicPlaylist
{
    class Song
    {
        //initialize as "0" for strings
        public string Name { get; set; } = "";
        public string Artist { get; set; } = "";
        public string Album { get; set; } = "";
        public string Genre { get; set; } = "";
        public double Size { get; set; }
        public double Time { get; set; }
        public int Year { get; set; }
        public int Plays { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Artist: {Artist}, Album: {Album}, Genre: {Genre}, Size: {Size}, Time: {Time}, Year: {Year}, Plays: {Plays}";}}

    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
            Console.WriteLine("Usage: AnalyzeMusicPlaylist <inputFilePath> <outputFilePath>");
            return;}

            string inputFilePath = args[0];
            string outputFilePath = args[1];

            List<Song> songs = new List<Song>();

            //read playlist and parse for songssong data
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
            reader.ReadLine(); //skip header
            string line;
            while ((line = reader.ReadLine()) != null)
                {
                string[] data = line.Split('\t');
                if (data.Length == 8)
                    {
                    Song song = new Song
                        {
                        Name = data[0],
                        Artist = data[1],
                        Album = data[2],
                        Genre = data[3],
                        Size = double.Parse(data[4]),
                        Time = double.Parse(data[5]),
                        Year = int.Parse(data[6]),
                        Plays = int.Parse(data[7])
                        };
                        songs.Add(song);}}}

            //generate the report and write it to the output file
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
            writer.WriteLine("Music Playlist Analysis Report");
            writer.WriteLine("---------------------------------");

            int songsWith200OrMorePlays = songs.Count(song => song.Plays >= 200);
            int alternativeGenreSongs = songs.Count(song => song.Genre == "Alternative");
            int hipHopRapGenreSongs = songs.Count(song => song.Genre == "Hip-Hop/Rap");
            var songsFromFishbowlAlbum = songs.Where(song => song.Album == "Welcome to the Fishbowl").ToList();
            var songsBefore1970 = songs.Where(song => song.Year < 1970).ToList();
            var longSongNames = songs.Where(song => song.Name.Length > 85).Select(song => song.Name).ToList();
            var longestSong = songs.OrderByDescending(song => song.Time).First();
            var uniqueGenres = songs.Select(song => song.Genre).Distinct().ToList();
            var songsProducedEachYear = songs.GroupBy(song => song.Year).ToDictionary(group => group.Key, group => group.Count());
            var totalPlaysPerYear = songs.GroupBy(song => song.Year).ToDictionary(group => group.Key, group => group.Sum(s => s.Plays));
            var uniqueArtists = songs.Select(song => song.Artist).Distinct().ToList();

            writer.WriteLine($"Songs with 200 or more plays: {songsWith200OrMorePlays}");
            writer.WriteLine($"Songs with Genre 'Alternative': {alternativeGenreSongs}");
            writer.WriteLine($"Songs with Genre 'Hip-Hop/Rap': {hipHopRapGenreSongs}");
            writer.WriteLine("Songs from the album 'Welcome to the Fishbowl':");
            foreach (var song in songsFromFishbowlAlbum)
                {
                writer.WriteLine(song.ToString());}
                writer.WriteLine("Songs from before 1970:");
                foreach (var song in songsBefore1970)
                {
                writer.WriteLine(song.ToString());}
                writer.WriteLine("Song names longer than 85 characters:");
                foreach (var songName in longSongNames)
                {
                writer.WriteLine(songName);}
                writer.WriteLine("Longest Song:");
                writer.WriteLine(longestSong.ToString());
                writer.WriteLine("Unique Genres:");
                foreach (var genre in uniqueGenres)
                {
                    writer.WriteLine(genre);}
                writer.WriteLine("Songs produced each year:");
                foreach (var entry in songsProducedEachYear)
                {
                writer.WriteLine($"{entry.Key}: {entry.Value} songs");}
                writer.WriteLine("Total Plays per year:");
                foreach (var entry in totalPlaysPerYear)
                {
                writer.WriteLine($"{entry.Key}: {entry.Value} plays");}
                writer.WriteLine("Unique Artists:");
                foreach (var artist in uniqueArtists)
                {
                writer.WriteLine(artist);}

                Console.WriteLine("Report generated and saved to the output file successfully.");
            }}}}