namespace GameHandling
{
    [System.Serializable]
    public class jsonListImp
    {
        public string name;
        public bool value;

        public jsonListImp(string name, bool value)
        {
            this.name = name;
            this.value = value;
        }

        public string getName()
        {
            return name;
        }

        public bool getValue()
        {
            return value;
        }
    }
}