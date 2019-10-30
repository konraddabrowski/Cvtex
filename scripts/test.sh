#!/bin/bash
projects=(Cvtex.Tests Cvtex.Tests.E2E)
for project in ${projects[*]}
do
	echo Running tests for: $project
	dotnet test ../tests/$project/$project.csproj
done
