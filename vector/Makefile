CSC = 
.PHONEY:all
all: out.txt
	cat out.txt
out.txt : main.exe 
	mono main.exe > out.txt
main.exe: main.cs vector.dll
	$(CSC) -reference:$(word 2,$^) $<
vector.dll : vector.cs
	$(CSC) -target:library -out:$@ $<
