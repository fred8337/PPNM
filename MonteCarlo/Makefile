.PHONY : clean
all: out.txt plot.svg
	cat out.txt
out.txt: main.exe
	mono $<> $@
main.exe: main.cs matlib.dll
	mcs -reference:matlib.dll $<
matlib.dll: ../matlib/matrix/vector.cs ../matlib/matrix/matrix.cs montecarlo.cs
	mcs -target:library -out:$@ $^
# matlib.dll: ../../Elias/problems/matlib/matrix/matrix.cs ../../Elias/problems/matlib/matrix/vector.cs LinEq.cs
# 	mcs -target:library -out:$@ $^
plot.svg: plot.gpi error.txt
	gnuplot $<
clean:
	@echo Clean?
	rm -f *.dll *.exe log* out*  