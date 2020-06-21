CSFLAGS = mcs -warn:4 -optimize-

out.txt : main.exe 
	mono $< > $@
main.exe : main.cs
	$(CSFLAGS) $<
clean: 
	rm -f out.txt main.exe