﻿using System.Drawing;

namespace GGO.Common
{
    public class Calculations
    {
        /// <summary>
        /// Gets the position of the dividers either for the player or the squad members.
        /// </summary>
        /// <param name="Player">If the divider positions are for the player.</param>
        /// <param name="Count">The number for the squad member.</param>
        /// <returns>An array with the 5 positions.</returns>
        public static Point[] GetDividerPositions(Configuration Config, bool Player, int Count = 0)
        {
            // Create a list of dividers
            Point[] Positions = new Point[5];

            // Store our positions for the player or squad members
            Point InfoPosition = Player ? Config.PlayerInfo : GetSquadPosition(Config, Count, true);
            Size HealthSize = Player ? Config.PlayerHealthSize : Config.SquadHealthSize;
            Size HealthPosition = Player ? Config.PlayerHealthPos : Config.SquadHealthPos;

            // For the dividers, get the distance between each one of them
            int HealthSep = HealthSize.Width / 4;

            // Itterate from 0 to 4 to create our separators
            for (int Separator = 0; Separator < 5; Separator++)
            {
                // Calculate the position of the separator and add it in the array
                Positions[Separator] = (InfoPosition + HealthPosition) + new Size(HealthSep * Separator, 0) + Config.DividerPosition;
            }

            // Finally, return the divider positions
            return Positions;
        }

        /// <summary>
        /// Gets the specific position for the squad member.
        /// </summary>
        /// <param name="Count">The index of the squad member (zero based).</param>
        /// <param name="Info">If the location of the info should be returned.</param>
        /// <returns>A Point with the on screen position.</returns>
        public static Point GetSquadPosition(Configuration Config, int Count, bool Info = false)
        {
            Count++;

            if (Info)
            {
                return new Point(Config.SquadPosition.X + Config.SquaredBackground.Width + Config.CommonSpace.Width, (Config.SquadPosition.Y + Config.CommonSpace.Height) * Count);
            }
            else
            {
                return new Point(Config.SquadPosition.X, (Config.SquadPosition.Y + Config.CommonSpace.Height) * Count);
            }
        }
    }
}
