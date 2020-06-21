all: out.txt plot.svg
out.txt: main.exe
	mono $<> $@
main.exe: main.cs
	mcs  $<
plot.svg: plot.gpi
	gnuplot $<
clean:
	rm -f *.dll *.exe log* out* 