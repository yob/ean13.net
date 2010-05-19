# coding: utf-8

require 'rake'

task :default => :test

COMPILER = "/home/jh/downloads/FSharp-2.0.0.0/bin/fsc.exe"
desc "Default Task"
task :default => [ :compile ]

desc "Compile the app"
task :compile do
  `#{COMPILER} --target:library --out:EAN13.dll src/*.fs`
end

desc "Compile the app"
task :compile_app => :compile do
  `gmcs -pkg:dotnet -r:EAN13.dll -out:ean13app.exe src/*.cs`
end

desc "run unit tests"
task :test => :compile do
  `gmcs -pkg:dotnet -r:EAN13.dll -target:library -out:ean13test.dll -pkg:nunit test/*.cs`
  puts `nunit-console ean13test.dll`
end
