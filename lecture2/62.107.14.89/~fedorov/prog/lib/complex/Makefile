all: out.txt
	cat $<
out.txt: main.exe
	mono $< > $@
main.exe: main.cs complex/cmath.dll
	mcs $< -reference:$(word 2,$^)
cmath.dll: cmath.cs complex/complex.cs 
	mcs $^ -target:library -out:$@
clean:
	$(RM) *.dll *.exe out*
