using System.Collections.Generic;
using System.Drawing;

namespace bsc_sc_path_finder
{
    public class JobType
    {
        public string Name { get; }

        public Image Sprite { get; }

        public JobType(
            string name,
            Image sprite)
        {
            Name = name;
            Sprite = sprite;
        }
    }
}