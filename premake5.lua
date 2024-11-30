solution "GameOfLife"
    location "bin"
    configurations { "Debug", "Release" }
    project "game"
        kind "ConsoleApp"
        language "C#"
        files { "src/**.cs" }
        filter "configurations:Debug"
            defines { "DEBUG" }
        filter "configurations:Release"
            defines { "NDEBUG" }