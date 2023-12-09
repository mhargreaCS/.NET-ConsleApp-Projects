using System;

namespace SVRECT

{
    public class SVGRect
    {
        private float width = 1; private float height = 1;
        private string fillColor = "#0000FF"; private string strokeColor = "0F0F0F";
        private float strokeWidth = 1.0f;
        private float offsetX = 0; private float offsetY = 0;

        public SVGRect(float width, float height, string fillColor, string strokeColor)
        {
            this.width = width;
            this.height = height;
            this.fillColor = fillColor;
            this.strokeColor = strokeColor;
        }

        public bool setDimensions(float width, float height)
        {
            bool valid = false;
            if (width > 0 && height > 0)
            {
                this.width = width; this.height = height;
                Console.WriteLine("Rectangle updated!");
                valid = true;
            }
            else if (height < 0 || width < 0)
            {
                Console.WriteLine("Invalid input – rectangle not changed.");
                valid = false;
            }
            return valid;
        }

        public void setOffsets(float offsetX, float offsetY)
        {
            this.offsetX = offsetX;
            this.offsetY = offsetY;
            Console.WriteLine("Rectangle updated!");
        }

        public bool set_fill_and_stroke(string fillColor, string strokeColor, float strokeWidth)
        {
            bool valid = false;
            if (strokeWidth > 0)
            {
                this.fillColor = fillColor; this.strokeColor = strokeColor; this.strokeWidth = strokeWidth;
                Console.WriteLine("Rectangle updated!");
                valid = true;
            }
            else if (strokeWidth < 0)
            {
                Console.WriteLine("Invalid input – rectangle not changed.");
                valid = false;
            }
            return valid;
        }

        public void Print_XML()
        {
            Console.WriteLine("\n<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + "\n<svg" + "\n   xmlns=\"http://www.w3.org/2000/svg\"\r\n   xmlns:svg=\"http://www.w3.org/2000/svg\">" + "\n  <rect");
            Console.WriteLine("     style=\"fill:" + this.fillColor + "; stroke:" + this.strokeColor + "; stroke-width:" + this.strokeWidth + "\""); // Replace fill, stoke, and stroke width variable values
            Console.WriteLine("     width=\"" + this.width + "\"" + "\n     height=\"" + this.height + "\""); // Replace width and height with correct variables
            Console.WriteLine("     x=\"" + this.offsetX + "\"" + "\n     y=\"" + this.offsetY + "\" />" + "\n</svg>"); // replace with x and y offset vaules
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("[SVG Class]");
            Console.Write("Rectangle width: "); float width = Convert.ToSingle(Console.ReadLine());
            Console.Write("Rectangle height: "); float height = Convert.ToSingle(Console.ReadLine());
            Console.Write("Fill color: "); string fillColor = Console.ReadLine();
            Console.Write("Stroke color: "); string strokeColor = Console.ReadLine();

            SVGRect image1 = new SVGRect(width, height, fillColor, strokeColor);
            // MAIN LOOP
            bool loopParam = true;
            do
            {
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("1) Change the Rectangle size\r\n2) Update the Fill and Stroke settings\r\n3) Move the Rectangle\r\n4) Print valid XML\r\n5) Quit");

                Console.Write("Option: "); byte input = Convert.ToByte(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        Console.Write("\nEnter a width: "); width = Convert.ToSingle(Console.ReadLine());
                        Console.Write("Enter a height: "); height = Convert.ToSingle(Console.ReadLine());
                        image1.setDimensions(width, height);
                        break;
                    case 2:
                        Console.Write("\nEnter a new fill color: "); fillColor = Console.ReadLine();
                        Console.Write("Enter a new stroke color: "); strokeColor = Console.ReadLine();
                        Console.Write("Enter a new stroke width: "); float strokeWidth = Convert.ToSingle(Console.ReadLine());
                        image1.set_fill_and_stroke(fillColor, strokeColor, strokeWidth);
                        break;
                    case 3:
                        Console.Write("\nEnter a new  offset x: "); float offsetX = Convert.ToSingle(Console.ReadLine());
                        Console.Write("Enter a new offset y: "); float offsetY = Convert.ToSingle(Console.ReadLine());
                        image1.setOffsets(offsetX, offsetY);
                        break;
                    case 4:
                        image1.Print_XML();
                        break;
                    case 5:
                        Console.WriteLine("Closing!");
                        loopParam = false;
                        break;
                }
            } while (loopParam);

        }

    }

}
