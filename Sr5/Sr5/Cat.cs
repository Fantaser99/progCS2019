namespace Sr5
{
    public class Cat
    {
        public string Name { get; private set; }
        private string[] _meows;

        /// <summary>
        /// Generate a new Cat object
        /// </summary>
        /// <param name="name">Cat's name</param>
        /// <param name="meows">List of the cat's meowing capabilities</param>
        public Cat(string name, string[] meows)
        {
            Name = name;

            // Explicitly copying
            _meows = new string[meows.Length];
            for (int i = 0; i < meows.Length; i++)
            {
                _meows[i] = meows[i];
            }
        }

        // Read-only indexer
        public string this[int key] => _meows[key];

        public int Length
        {
            get { return _meows.Length; }
        }
    }
}