.PHONY : clean
all: out.txt
	cat out.txt
out.txt: main.exe
	mono $<> $@
main.exe: main.cs matlib.dll
	mcs -reference:matlib.dll $<

matlib.dll: ../matlib/matrix/vector.cs ../matlib/matrix/matrix.cs Integrator.cs ../matlib/integration/quado8.cs
	mcs -target:library -out:$@ $^
# matlib.dll: ../../Elias/problems/matlib/matrix/matrix.cs ../../Elias/problems/matlib/matrix/vector.cs LinEq.cs
# 	mcs -target:library -out:$@ $^
# plot.svg: plot.gpi Plot.txt
# 	gnuplot $<
clean:
	@echo Clean?
	rm -f *.dll *.exe log* out* 