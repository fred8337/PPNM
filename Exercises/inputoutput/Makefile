CSC = mcs
.PHONEY:all
all: out.txt out-stdin.txt Makefile
	cat out.txt
out.txt : cmdline.exe input.txt Makefile # >> means append
	mono $< 1 2 3 4 5 1> $@
	# mono $< $$(cat input.txt) 1>> $@
out-stdin.txt out-stderr.txt: stdin.exe input.txt Makefile
	mono $< < input.txt 1> out-stdin.txt 2> out-stderr.txt
	# cat input.txt | mono $< >> $out-stdin.txt 2>> out-stderr.txt
cmdline.exe: cmdline.cs
	$(CSC) $<
stdin.exe: stdin.cs
	$(CSC) $<
clean:
	$(RM) *.exe out*
# input.txt: Makefile
# 	/bin/echo -e '0.5\n2.5\n3.5' > $@
