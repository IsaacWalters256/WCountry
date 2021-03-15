## Security Alerts before fixxing
* _Cross Site Scripting_ 2, High, Low confidence
* _	Both are involded in the log in area.
* _Imcomplete or no cashe control and pragma HTTp header set_ 32 Low Medium
* _Server leaks information via "X-Powered-By" HTTP Response Header Field_ 42 Low Medium
* _X content Type Options Header Missing_ 34 Low Medium


<p>Overall I am very happy with how the site proformed during testing.</p>
<p>I dont thing any of these need to be fixxed, the High level one is most likely a false positive.</p>
<p>And I've looked over the server leaks information one before. There were also three other low risk ones but they also had low confidence.</p>
