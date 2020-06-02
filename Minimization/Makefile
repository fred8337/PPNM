all: out.txt
	cat out.txt
out.txt: main.exe
	mono $<> $@
main.exe: main.cs matlib.dll
	mcs -reference:matlib.dll $<
matlib.dll: ../matlib/matrix/vector.cs qnewton.cs ../matlib/matrix/matrix.cs
	mcs -target:library -out:$@ $^
# plot.svg: plot.gpi out.txt
# 	gnuplot $<
clean:
	rm -f *.dll *.exe log* out* 