all: out.txt plot.svg
out.txt: main.exe
	mono $<> $@
main.exe: main.cs matlib.dll
	mcs -reference:matlib.dll $<
matlib.dll: ../matlib/matrix/vector.cs ../matlib/ode/ode.cs Lspline.cs
	mcs -target:library -out:$@ $^
plot.svg: plot.gpi out.txt
	gnuplot $<
clean:
	rm -f *.dll *.exe log* out* 