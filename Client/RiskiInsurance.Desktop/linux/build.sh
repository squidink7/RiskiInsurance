cp Riski.desktop build/
cp icon.svg build/

rm build/*.dbg
rm build/*.pdb

mv build/RiskiInsuranceDesktop build/AppRun

appimagetool build/