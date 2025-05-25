<%@ Control Language="vb" AutoEventWireup="false" Codebehind="Scheduler.ascx.vb" Inherits="WebScheduler.Scheduler" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<script language=javascript>
<!--
function UpdateScheduleType(){
	
	var sType = form1["Scheduler1:selScheduleType"].value;
	
	tblHour.style.display = "none"
	tblDayRepeat.style.display = "none";
	tblWeekRepeat.style.display = "none";
	tblDaysOfWeek.style.display = "none";
	tblMonths.style.display = "none";
	tblWeekOfMonth.style.display = "none";
	tblCalendar.style.display = "none";

	switch(sType){
		case "Hourly":
			tblHour.style.display = "";
			break;
		case "Weekly":
			tblDaysOfWeek.style.display = "";
			break;
		case "Daily":
			tblDayRepeat.style.display = "";
			break;
		case "WeeklySkip":
			tblWeekRepeat.style.display = "";
			tblDaysOfWeek.style.display = "";
			break;
		case "WeekNumber":
			tblMonths.style.display = "";
			tblWeekOfMonth.style.display = "";
			tblDaysOfWeek.style.display = "";
			break;
		case "Calendar":
			tblMonths.style.display = "";
			tblCalendar.style.display = "";
			break;
	}
}
//-->
</script>

<asp:Panel id=pnName runat="server">

	<h1>Shared Schedule</h1>

	<p>
	<TABLE BORDER="0" CELLSPACING="1" CELLPADDING="1">
	<TR>
		<TD>Name</TD>
		<TD>
	<asp:TextBox id=txtScheduleName runat="server"></asp:TextBox></TD></TR>
	</TABLE>
	</p>

</asp:Panel>

<fieldset>
<legend>
	<asp:dropdownlist id=selScheduleType runat="server" onchange="UpdateScheduleType()">
		<asp:ListItem value="Hourly">Hourly</asp:ListItem>
		<asp:ListItem value="Daily">Daily</asp:ListItem>
		<asp:ListItem value="Weekly">Weekly</asp:ListItem>
		<asp:ListItem value="WeeklySkip">Weekly skip</asp:ListItem>
		<asp:ListItem value="WeekNumber">Week number</asp:ListItem>
		<asp:ListItem value="Calendar">Calendar</asp:ListItem>
		<asp:ListItem value="Once">Run once</asp:ListItem>
	</asp:dropdownlist>
</legend>
<TABLE id=tblHour cellSpacing=1 cellPadding=1 border=0>
  <TR>
    <td>Run the schedule every:</td>
    <TD><asp:textbox id=txtEveryHour runat="server" Width="30px">1</asp:textbox></TD>
    <TD>hours</TD>
    <TD><asp:dropdownlist id=selEveryMinute runat="server">
<asp:ListItem Value="00">00</asp:ListItem>
<asp:ListItem Value="01">01</asp:ListItem>
<asp:ListItem Value="02">02</asp:ListItem>
<asp:ListItem Value="03">03</asp:ListItem>
<asp:ListItem Value="04">04</asp:ListItem>
<asp:ListItem Value="05">05</asp:ListItem>
<asp:ListItem Value="06">06</asp:ListItem>
<asp:ListItem Value="07">07</asp:ListItem>
<asp:ListItem Value="08">08</asp:ListItem>
<asp:ListItem Value="09">09</asp:ListItem>
<asp:ListItem Value="10">10</asp:ListItem>
<asp:ListItem Value="11">11</asp:ListItem>
<asp:ListItem Value="12">12</asp:ListItem>
<asp:ListItem Value="13">13</asp:ListItem>
<asp:ListItem Value="14">14</asp:ListItem>
<asp:ListItem Value="15">15</asp:ListItem>
<asp:ListItem Value="16">16</asp:ListItem>
<asp:ListItem Value="17">17</asp:ListItem>
<asp:ListItem Value="18">18</asp:ListItem>
<asp:ListItem Value="19">19</asp:ListItem>
<asp:ListItem Value="20">20</asp:ListItem>
<asp:ListItem Value="21">21</asp:ListItem>
<asp:ListItem Value="22">22</asp:ListItem>
<asp:ListItem Value="23">23</asp:ListItem>
<asp:ListItem Value="24">24</asp:ListItem>
<asp:ListItem Value="25">25</asp:ListItem>
<asp:ListItem Value="26">26</asp:ListItem>
<asp:ListItem Value="27">27</asp:ListItem>
<asp:ListItem Value="28">28</asp:ListItem>
<asp:ListItem Value="29">29</asp:ListItem>
<asp:ListItem Value="30">30</asp:ListItem>
<asp:ListItem Value="31">31</asp:ListItem>
<asp:ListItem Value="32">32</asp:ListItem>
<asp:ListItem Value="33">33</asp:ListItem>
<asp:ListItem Value="34">34</asp:ListItem>
<asp:ListItem Value="35">35</asp:ListItem>
<asp:ListItem Value="36">36</asp:ListItem>
<asp:ListItem Value="37">37</asp:ListItem>
<asp:ListItem Value="38">38</asp:ListItem>
<asp:ListItem Value="39">39</asp:ListItem>
<asp:ListItem Value="40">40</asp:ListItem>
<asp:ListItem Value="41">41</asp:ListItem>
<asp:ListItem Value="42">42</asp:ListItem>
<asp:ListItem Value="43">43</asp:ListItem>
<asp:ListItem Value="44">44</asp:ListItem>
<asp:ListItem Value="45">45</asp:ListItem>
<asp:ListItem Value="46">46</asp:ListItem>
<asp:ListItem Value="47">47</asp:ListItem>
<asp:ListItem Value="48">48</asp:ListItem>
<asp:ListItem Value="49">49</asp:ListItem>
<asp:ListItem Value="50">50</asp:ListItem>
<asp:ListItem Value="51">51</asp:ListItem>
<asp:ListItem Value="52">52</asp:ListItem>
<asp:ListItem Value="53">53</asp:ListItem>
<asp:ListItem Value="54">54</asp:ListItem>
<asp:ListItem Value="55">55</asp:ListItem>
<asp:ListItem Value="56">56</asp:ListItem>
<asp:ListItem Value="57">57</asp:ListItem>
<asp:ListItem Value="58">58</asp:ListItem>
<asp:ListItem Value="59">59</asp:ListItem>
</asp:dropdownlist></TD>
    <TD>minutes</TD></TR></TABLE>
<TABLE id=tblDaysOfWeek cellSpacing=1 cellPadding=1 border=0>
  <TR>
    <TD style="HEIGHT: 21px" colSpan=7>On the following days:</TD></TR>
  <TR>
    <TD><asp:checkbox id=chkSun runat="server" Text="Sun"></asp:checkbox></TD>
    <TD><asp:checkbox id=chkMon runat="server" Text="Mon"></asp:checkbox></TD>
    <TD><asp:checkbox id=chkTue runat="server" Text="Tue"></asp:checkbox></TD>
    <TD><asp:checkbox id=chkWed runat="server" Text="Wed"></asp:checkbox></TD>
    <TD><asp:checkbox id=chkThu runat="server" Text="Thu"></asp:checkbox></TD>
    <TD><asp:checkbox id=chkFri runat="server" Text="Fri"></asp:checkbox></TD>
    <TD><asp:checkbox id=chkSat runat="server" Text="Sat"></asp:checkbox></TD></TR></TABLE>
<TABLE id=tblWeekOfMonth cellSpacing=1 cellPadding=1 border=0>
  <TR>
    <TD>On week of month</TD>
    <TD><asp:dropdownlist id=selWeekOfMonth runat="server">
		<asp:ListItem Value="1">1st</asp:ListItem>
		<asp:ListItem Value="2">2nd</asp:ListItem>
		<asp:ListItem Value="3">3rd</asp:ListItem>
		<asp:ListItem Value="4">4th</asp:ListItem>
		<asp:ListItem Value="5">Last</asp:ListItem>
		</asp:dropdownlist></TD></TR></TABLE>
<TABLE id=tblDayRepeat cellSpacing=1 cellPadding=1 border=0>
  <TR>
    <TD>Repeat after this number of days:</TD>
    <TD><asp:textbox id=txtRepeatDays runat="server" Width="30px">1</asp:textbox></TD></TR></TABLE>
<TABLE id=tblWeekRepeat cellSpacing=1 cellPadding=1 border=0>
  <TR>
    <TD>Repeat after this number of weeks: </TD>
    <TD><asp:textbox id=txtRepeatWeek runat="server" Width="30px">1</asp:textbox></TD></TR></TABLE>
<TABLE id=tblMonths cellSpacing=1 cellPadding=1 border=0>
  <TR>
    <TD>Months:</TD>
    <TD><asp:checkbox id=chkJan runat="server" Text="Jan"></asp:checkbox></TD>
    <TD><asp:checkbox id=chkApr runat="server" Text="Apr"></asp:checkbox></TD>
    <TD><asp:checkbox id=chkJul runat="server" Text="Jul"></asp:checkbox></TD>
    <TD><asp:checkbox id=chkOct runat="server" Text="Oct"></asp:checkbox></TD></TR>
  <TR>
    <TD></TD>
    <TD><asp:checkbox id=chkFeb runat="server" Text="Feb"></asp:checkbox></TD>
    <TD><asp:checkbox id=chkMay runat="server" Text="May"></asp:checkbox></TD>
    <TD><asp:checkbox id=chkAug runat="server" Text="May"></asp:checkbox></TD>
    <TD><asp:checkbox id=chkNov runat="server" Text="Nov"></asp:checkbox></TD></TR>
  <TR>
    <TD></TD>
    <TD><asp:checkbox id=chkMar runat="server" Text="Mar"></asp:checkbox></TD>
    <TD><asp:checkbox id=chkJun runat="server" Text="Jun"></asp:checkbox></TD>
    <TD><asp:checkbox id=chkSep runat="server" Text="Sep"></asp:checkbox></TD>
    <TD><asp:checkbox id=chkDec runat="server" Text="Dec"></asp:checkbox></TD></TR></TABLE>
<TABLE id=tblCalendar cellSpacing=1 cellPadding=1 width=300 border=0>
  <tr>
    <td colSpan=10>Calendar days</td></tr>
  <TR>
    <TD><asp:checkbox id=chkDay1 runat="server" Text="1"></asp:checkbox></TD>
    <TD><asp:checkbox id=chkDay2 runat="server" Text="2"></asp:checkbox></TD>
    <TD><asp:checkbox id=chkDay3 runat="server" Text="3"></asp:checkbox></TD>
    <TD><asp:checkbox id=chkDay4 runat="server" Text="4"></asp:checkbox></TD>
    <TD><asp:checkbox id=chkDay5 runat="server" Text="5"></asp:checkbox></TD>
    <TD><asp:checkbox id=chkDay6 runat="server" Text="6"></asp:checkbox></TD>
    <TD><asp:checkbox id=chkDay7 runat="server" Text="7"></asp:checkbox></TD>
    <TD><asp:checkbox id=chkDay8 runat="server" Text="8"></asp:checkbox></TD>
    <TD><asp:checkbox id=chkDay9 runat="server" Text="9"></asp:checkbox></TD>
    <TD><asp:checkbox id=chkDay10 runat="server" Text="10"></asp:checkbox></TD>
    <td colSpan=2></td></TR>
  <TR>
    <TD><asp:checkbox id=chkDay11 runat="server" Text="11"></asp:checkbox></TD>
    <TD><asp:checkbox id=chkDay12 runat="server" Text="12"></asp:checkbox></TD>
    <TD><asp:checkbox id=chkDay13 runat="server" Text="13"></asp:checkbox></TD>
    <TD><asp:checkbox id=chkDay14 runat="server" Text="14"></asp:checkbox></TD>
    <TD><asp:checkbox id=chkDay15 runat="server" Text="15"></asp:checkbox></TD>
    <TD><asp:checkbox id=chkDay16 runat="server" Text="16"></asp:checkbox></TD>
    <TD><asp:checkbox id=chkDay17 runat="server" Text="17"></asp:checkbox></TD>
    <TD><asp:checkbox id=chkDay18 runat="server" Text="18"></asp:checkbox></TD>
    <TD><asp:checkbox id=chkDay19 runat="server" Text="19"></asp:checkbox></TD>
    <TD><asp:checkbox id=chkDay20 runat="server" Text="20"></asp:checkbox></TD>
    <td colSpan=2></td></TR>
  <TR>
    <TD><asp:checkbox id=chkDay21 runat="server" Text="21"></asp:checkbox></TD>
    <TD><asp:checkbox id=chkDay22 runat="server" Text="22"></asp:checkbox></TD>
    <TD><asp:checkbox id=chkDay23 runat="server" Text="23"></asp:checkbox></TD>
    <TD><asp:checkbox id=chkDay24 runat="server" Text="24"></asp:checkbox></TD>
    <TD><asp:checkbox id=chkDay25 runat="server" Text="25"></asp:checkbox></TD>
    <TD><asp:checkbox id=chkDay26 runat="server" Text="26"></asp:checkbox></TD>
    <TD><asp:checkbox id=chkDay27 runat="server" Text="27"></asp:checkbox></TD>
    <TD><asp:checkbox id=chkDay28 runat="server" Text="28"></asp:checkbox></TD>
    <TD><asp:checkbox id=chkDay29 runat="server" Text="29"></asp:checkbox></TD>
    <TD><asp:checkbox id=chkDay30 runat="server" Text="30"></asp:checkbox></TD>
    <td><asp:checkbox id=chkDay31 runat="server" Text="31"></asp:checkbox></td>
    <td><asp:checkbox id=chkDayLast runat="server" Text="Last"></asp:checkbox></td></TR></TABLE>
<TABLE cellSpacing=1 cellPadding=0 border=0>
  <TR>
    <TD>Start Time:</TD>
    <td>
      <table>
        <TR>
          <TD><asp:dropdownlist id=selStartHour runat="server">
<asp:ListItem Value="1">1</asp:ListItem>
<asp:ListItem Value="2" Selected="True">2</asp:ListItem>
<asp:ListItem Value="3">3</asp:ListItem>
<asp:ListItem Value="4">4</asp:ListItem>
<asp:ListItem Value="5">5</asp:ListItem>
<asp:ListItem Value="6">6</asp:ListItem>
<asp:ListItem Value="7">7</asp:ListItem>
<asp:ListItem Value="8">8</asp:ListItem>
<asp:ListItem Value="9">9</asp:ListItem>
<asp:ListItem Value="10">10</asp:ListItem>
<asp:ListItem Value="11">11</asp:ListItem>
<asp:ListItem Value="12">12</asp:ListItem>

<asp:ListItem Value="13">13</asp:ListItem>
<asp:ListItem Value="14">14</asp:ListItem>
<asp:ListItem Value="15">15</asp:ListItem>
<asp:ListItem Value="16">16</asp:ListItem>
<asp:ListItem Value="17">17</asp:ListItem>
<asp:ListItem Value="18">18</asp:ListItem>
<asp:ListItem Value="19">19</asp:ListItem>
<asp:ListItem Value="20">20</asp:ListItem>
<asp:ListItem Value="21">21</asp:ListItem>
<asp:ListItem Value="22">22</asp:ListItem>
<asp:ListItem Value="23">23</asp:ListItem>
<asp:ListItem Value="24">24</asp:ListItem>
</asp:dropdownlist></TD>
          <TD>:</TD>
          <TD><asp:dropdownlist id=selStartMin runat="server">
<asp:ListItem Value="00">00</asp:ListItem>
<asp:ListItem Value="01">01</asp:ListItem>
<asp:ListItem Value="02">02</asp:ListItem>
<asp:ListItem Value="03">03</asp:ListItem>
<asp:ListItem Value="04">04</asp:ListItem>
<asp:ListItem Value="05">05</asp:ListItem>
<asp:ListItem Value="06">06</asp:ListItem>
<asp:ListItem Value="07">07</asp:ListItem>
<asp:ListItem Value="08">08</asp:ListItem>
<asp:ListItem Value="09">09</asp:ListItem>
<asp:ListItem Value="10">10</asp:ListItem>
<asp:ListItem Value="11">11</asp:ListItem>
<asp:ListItem Value="12">12</asp:ListItem>
<asp:ListItem Value="13">13</asp:ListItem>
<asp:ListItem Value="14">14</asp:ListItem>
<asp:ListItem Value="15">15</asp:ListItem>
<asp:ListItem Value="16">16</asp:ListItem>
<asp:ListItem Value="17">17</asp:ListItem>
<asp:ListItem Value="18">18</asp:ListItem>
<asp:ListItem Value="19">19</asp:ListItem>
<asp:ListItem Value="20">20</asp:ListItem>
<asp:ListItem Value="21">21</asp:ListItem>
<asp:ListItem Value="22">22</asp:ListItem>
<asp:ListItem Value="23">23</asp:ListItem>
<asp:ListItem Value="24">24</asp:ListItem>
<asp:ListItem Value="25">25</asp:ListItem>
<asp:ListItem Value="26">26</asp:ListItem>
<asp:ListItem Value="27">27</asp:ListItem>
<asp:ListItem Value="28">28</asp:ListItem>
<asp:ListItem Value="29">29</asp:ListItem>
<asp:ListItem Value="30">30</asp:ListItem>
<asp:ListItem Value="31">31</asp:ListItem>
<asp:ListItem Value="32">32</asp:ListItem>
<asp:ListItem Value="33">33</asp:ListItem>
<asp:ListItem Value="34">34</asp:ListItem>
<asp:ListItem Value="35">35</asp:ListItem>
<asp:ListItem Value="36">36</asp:ListItem>
<asp:ListItem Value="37">37</asp:ListItem>
<asp:ListItem Value="38">38</asp:ListItem>
<asp:ListItem Value="39">39</asp:ListItem>
<asp:ListItem Value="40">40</asp:ListItem>
<asp:ListItem Value="41">41</asp:ListItem>
<asp:ListItem Value="42">42</asp:ListItem>
<asp:ListItem Value="43">43</asp:ListItem>
<asp:ListItem Value="44">44</asp:ListItem>
<asp:ListItem Value="45">45</asp:ListItem>
<asp:ListItem Value="46">46</asp:ListItem>
<asp:ListItem Value="47">47</asp:ListItem>
<asp:ListItem Value="48">48</asp:ListItem>
<asp:ListItem Value="49">49</asp:ListItem>
<asp:ListItem Value="50">50</asp:ListItem>
<asp:ListItem Value="51">51</asp:ListItem>
<asp:ListItem Value="52">52</asp:ListItem>
<asp:ListItem Value="53">53</asp:ListItem>
<asp:ListItem Value="54">54</asp:ListItem>
<asp:ListItem Value="55">55</asp:ListItem>
<asp:ListItem Value="56">56</asp:ListItem>
<asp:ListItem Value="57">57</asp:ListItem>
<asp:ListItem Value="58">58</asp:ListItem>
<asp:ListItem Value="59">59</asp:ListItem>
</asp:dropdownlist></TD>
         
          </TR></table></td></TR>
  <TR>
    <TD>Start Date</TD>
    <TD><asp:textbox id=txtStartDate runat="server" Width="80px"></asp:textbox>
    
		<button type="reset" id="btnStartDate">...</button>
		<script type="text/javascript">
			Calendar.setup({
				inputField     :    "Scheduler1_txtStartDate",      // id of the input field
				ifFormat       :    "%m/%d/%Y",       // format of the input field
				button         :    "btnStartDate",   // trigger for the calendar (button ID)
				singleClick    :    true,           // double-click mode
				step           :    1                // show all years in drop-down boxes (instead of every other year as default)
			});
		</script>
    
    </TD></TR>
  <TR>
    <TD>End Date</TD>
    <TD><asp:textbox id=txtEndDate runat="server" Width="80px"></asp:textbox>
    
		<button type="reset" id="btnEndDate">...</button>
		<script type="text/javascript">
			Calendar.setup({
				inputField     :    "Scheduler1_txtEndDate",      // id of the input field
				ifFormat       :    "%m/%d/%Y",       // format of the input field
				button         :    "btnEndDate",   // trigger for the calendar (button ID)
				singleClick    :    true,           // double-click mode
				step           :    1                // show all years in drop-down boxes (instead of every other year as default)
			});
		</script>
    
    </TD></TR></TABLE>

</fieldset>