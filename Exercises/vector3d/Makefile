CSC = mcs
.PHONEY:all
all: out.txt
	cat out.txt
out.txt : main.exe 
	mono main.exe > out.txt
main.exe: main.cs vector3d.dll
	$(CSC) -reference:$(word 2,$^) $<
vector3d.dll : vector3d.cs
	$(CSC) -target:library -out:$@ $<
