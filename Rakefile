# coding: utf-8

require 'rake'

COMPILER = "/home/jh/downloads/FSharp-2.0.0.0/bin/fsc.exe"
desc "Default Task"
task :default => [ :compile ]

desc "Compile the app"
task :compile do
  `#{COMPILER} --target:exe --out:ean13.exe src/*.fs`
end
