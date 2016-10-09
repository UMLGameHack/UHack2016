## Inspiration
   We felt compelled to build a video game with some pretty interesting custom hardware.What is more interesting than an electric guitar?

## What it does
   Right now, it exists as a web app at imoutof.coffee (yes that is a URL). Users can play "Bard" with the keyboard from anywhere. 

## How we built it
   The game is built in Unity with C#. The unity code was compiled to an html5 application which was hosted on an aws site that was managed with flask.

## Challenges we ran into
    There is a bug in Unity that makes it impossible to process real time audio input.
	Early in the hackathon we chose to develop a hardware connection between the guitar and 
	the microphone port in the sound card. Due to that difficult to detect bug, such a route 
	made it impossible to perform a FFT on the guitar signal in Unity and therefore not useful for
	processing. The hardware team spent nearly 12 hours trying strange and arcane workarounds
	(including using a USB oscilloscope SDK to make sampling measurements and cutting up 
	earbuds to access the microphone input.)

## Accomplishments that we're proud of
    While not the technical marvel that we set out to build, we are still proud of the 
	development process that we all put into Bard. We all expanded into new roles and widened 
	our skillsets. Two of us came in without any C# knowledge, but left with tangible experience.
	As always, we are proud of our human interaction skills throughout the weekend despite 
	the lack of sleep.

## What we learned
    * *You can't process audio real time in Unity.*
    * how to overcome adversity and succeed as a team   	
	* How to put up a demo site with AWS and Flask(none of us had ever touched that before)
	* Some of the more advanced Unity features, like customized sprites and abstract C# classes
 

## What's next for Bard
	* Bard, the game is complete. We had fun with it, especially with the hardware challenges.
	   Three of the four members of our team will come back together to Hack AE. 
	   We might not try to do another hardware custom controller... but if we do, we'll
	   have the benefit of all this weekend's experience.