The program builds words cloud based on text. The text get split on words, punctuation and banned word (by defoult in the file function-words.txt) removed. Then first hundred or so of most frequent words gets layouted in ellipse. The more frequent a word is, the larger it will be. 
Options are following:
  -c, --count     (Default: 100) How many words should be in the cloud

  -s, --source    Required. Textfile

  -d, --dest      Required. Output file (without extension)

  --hec           (Default: 1) Horizontal extension coefficient

  --clr           (Default: Magenta) Color

  -f, --font      (Default: Arial) Font name

  --bw            (Default: function-words.txt) File with banned words

  --ext           (Default: png) Output file extension

  --width         (Default: 1000) Output file width

  --height        (Default: 1000) Output file height

  --help          Display this help screen.

Destination and source are required. Use -h or --help for help

And here goes so examples of clouds:
![Alt text](ExampleImages/wide.png?raw=true "Wide")
![Alt text](ExampleImages/high.png?raw=true "High")