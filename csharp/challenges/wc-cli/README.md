# WC-CLI
A command line tool that replicate the functions of UNIX command `wc`

# Usage
`./wc-cli [switch] [file]`

e.g `./wc-cli -l test.txt` or `cat test.txt | ./wc-cli`

List of available switch:
-c | count bytes in file
-l | count lines in file
-w | count words in file
-m | count characters in file
omit switch | count lines, words and bytes in file
without parameter | count lines, words and bytes from standard input