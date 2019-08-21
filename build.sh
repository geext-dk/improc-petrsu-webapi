rm -rf ./native/*
cd improc-petrsu
cargo-nuget pack --release
PACKAGE_NAME=$(ls improc_petrsu*.nupkg)

if [ ! -d ../native ]; then
	mkdir ../native
fi

cp $PACKAGE_NAME ../native
rm $PACKAGE_NAME
