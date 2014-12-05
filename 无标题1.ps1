$wordApp = New-Object -COM Word.Application
$file ='C:\Users\Administrator\Desktop\徐州二中素质指标库1.doc'
$doc = $wordApp.Documents.Open($file)

$text = $doc.Content.Text


$p="\d+\.\d+\.\d+[^\.][^(\d+\.)]+"
$s=$text
foreach($i in [RegEx]::Matches($s,$p))
{
$q=$i.Value
$b=[RegEx]::Matches($q,"^\d[^A\s]+")

$inp=""
$o=[RegEx]::Matches($q,"[ABCDEFGH][^ABCDEFGH]+")
$inp+=$b[0].Value 

foreach($i1 in $o){
$inp+=$i1.Value
}
$inp

}
 