out.txt: main.exe
	mono $< > $@
	cat out.txt
main.exe: main.cs matlib.dll
	mcs $< -reference:matlib.dll

LIBDIR =../matlib
SRC = $(LIBDIR)/integration/quado8.cs
SRC += $(LIBDIR)/integration/quado4.cs
matlib.dll: $(SRC)
	mcs $^ -target:library -out:$@

clean:
	rm -f *.exe out*