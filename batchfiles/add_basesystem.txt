git submodule add --force https://github.com/elicxir/ELICXIRs_BaseFramework.git Assets/BaseSystem
git commit -m "add base system"
cd Assets/BaseSystem
git config core.sparsecheckout true
echo /Assets/ > ../../.git/modules/Assets/BaseSystem/info/sparse-checkout
git read-tree -mu HEAD