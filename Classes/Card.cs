using System;
using System.Drawing;
using System.Windows.Forms;

namespace Blackjack.Classes
{
    /**
     * A generic playing card, capable of holding any value,
     * has seperate image for front, and back. Has tooltip
     * if face up
     */
    public class Card
    {
        bool isFlipped;
        Image front, back;
        int[] value;
        String display, name, charVal, suit;
        PictureBox frontBox = new PictureBox(), backBox = new PictureBox();

        public Card(String valueName, String charsVal, String suitT, int[] values)
        {
            this.display = charsVal + " of " + suitT;
            this.name = valueName;
            this.value = values;
            this.charVal = charsVal;
            this.suit = suitT;

            setImages();
            setBoxes();
        }

        // Makes sure to pull images out of the embedded resources correctly, before casting
        void setImages()
        {
            object obj = Properties.Resources.ResourceManager.GetObject("_" + name);
            object obj2 = Properties.Resources.ResourceManager.GetObject("back");

            if (obj is Image)
            {
                this.front = obj as Image;
            }

            if (obj2 is Image)
            {
                this.back = obj2 as Image;
            }
        }

        // Sets controls for face down and face up images
        void setBoxes()
        {
            int width = 100, height = 146;
            frontBox.SizeMode = PictureBoxSizeMode.StretchImage;
            frontBox.Width = width;
            frontBox.Height = height;
            frontBox.Image = this.Front;
            new ToolTip().SetToolTip(frontBox, this.Display);

            backBox.SizeMode = PictureBoxSizeMode.StretchImage;
            backBox.Width = width;
            backBox.Height = height;
            backBox.Image = this.Back;
        }

        /*
         * Getters and setters for each possible value stored in Card class
         */
        public PictureBox getDisplay()
        {

            if (this.Flipped)
            {
                return backBox;
            }
            else
            {
                return frontBox;
            }   
        }

        public bool Flipped
        {
            get
            {
                return this.isFlipped;
            }

            set
            {
                this.isFlipped = value;
            }
        }

        public Image Front
        {
            get
            {
                return this.front;
            }

            set
            {
                this.front = value;
            }
        }

        public Image Back
        {
            get
            {
                return this.back;
            }

            set
            {
                this.back = value;
            }
        }

        public int[] Values
        {
            get
            {
                return this.value;
            }

            set
            {
                this.value = value;
            }
        }

        public String Display
        {
            get
            {
                return this.display;
            }

            set
            {
                this.display = value;
            }
        }

        public String Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public String CharacterValue
        {
            get
            {
                return this.charVal;
            }
            set
            {
                charVal = value;
            }
        }

        public String Suit
        {
            get
            {
                return this.suit;
            }
            set
            {
                suit = value;
            }
        }
    }
}
