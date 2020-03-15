#
# Makefile C#
#
# Christian
# graetz23@gmail.com
# adapted 24.11.2019
# updated 14.03.2020
#
MAIN_FILE = SharpWave

# change this to the depth of the project folders
# if needed, add a preffix for a common project folder
CSHARP_SOURCE_FILES = $(wildcard */*/*.cs */*.cs *.cs)

# add needed flags to the compiler
# CSHARP_FLAGS = -optimize+ -w:1 -out:$(EXECUTABLE)
CSHARP_FLAGS = -w:1 -out:$(EXECUTABLE)

# change to the environment compiler
CSHARP_COMPILER = mcs

# if needed, change the executable file
EXECUTABLE = $(MAIN_FILE).exe

# if needed, change the remove command according to your system
RM_CMD = -rm -f $(EXECUTABLE)

all: $(EXECUTABLE)

$(EXECUTABLE): $(CSHARP_SOURCE_FILES)
	@ $(CSHARP_COMPILER) $(CSHARP_SOURCE_FILES) $(CSHARP_FLAGS)
	@ echo compiling...

run: all
	./$(EXECUTABLE)

clean:
	@ $(RM_CMD)

remake:
	@ $(MAKE) clean
	@ $(MAKE)
