using System.Collections.Generic;
using System.Drawing;

namespace bsc_sc_path_finder
{

    /// <summary>
    /// Defines a type of job that can be assigned to the robot.
    /// Contains a display name and a visual sprite for rendering.
    /// </summary>
    public class JobType
    {

        /// <summary>
        /// Gets the display name of the job type.
        /// </summary>
        public string Name { get; }



        /// <summary>
        /// Gets the sprite used to visually represent this job type.
        /// </summary>
        public Image Sprite { get; }

        /// <summary>
        /// Creates a new JobType definition.
        /// </summary>
        /// <param name="name">The name of the job type.</param>
        /// <param name="sprite">The image used for rendering this job type.</param>
        public JobType(
            string name,
            Image sprite)
        {
            Name = name;
            Sprite = sprite;
        }
    }
}