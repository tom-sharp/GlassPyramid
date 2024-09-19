
/*

	Find the time taken to fill a specific glass in a 2D glass pyramid

	where mainflow to the top glass is 1 volume unit and the volume of a glass is 10 volume units.
	Once the top glass is filled, it's flooding and starts to seed the glasses below.

				       Y		row 1 (glass 1)			      10			Time taken in
					  Y Y		row 2 (glass 1-2)		    30  30			seconds until
					 Y Y Y		row 3 (glass 1-3)         70  50  70		glass is filled
					Y Y Y Y		row 4 (glass 1-4)   	150	83	83	150

	Each glass has its own id, represented by the row it belongs to, and order in the row

	Default assumptions:
	main pyramid flow is 1 volume units per second
	glass volume is 10 volume units and all glasses of same size

 */


using GPCon;
using GlassPyramid;

var ui = new ConUI();

while (ui.UserInput())
{
	ui.Start();
	new Pyramid(ui).FindFillTime();
	ui.End();
}

