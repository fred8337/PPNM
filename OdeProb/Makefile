.PHONY : clean
all: out.txt plot.svg plotB.svg
	cat out.txt
out.txt: main.exe
	mono $<> $@
main.exe: main.cs matlib.dll
	mcs -reference:matlib.dll $<

matlib.dll: ../matlib/matrix/vector.cs ../matlib/matrix/matrix.cs OdeSolver.cs
	mcs -target:library -out:$@ $^
# matlib.dll: ../../Elias/problems/matlib/matrix/matrix.cs ../../Elias/problems/matlib/matrix/vector.cs LinEq.cs
# 	mcs -target:library -out:$@ $^
plot.svg: plot.gpi Plot.txt
	gnuplot $<
plotB.svg: plotB.gpi Plot2.txt
	gnuplot $<
clean:
	@echo Clean?
	rm -f *.dll *.exe log* out* 