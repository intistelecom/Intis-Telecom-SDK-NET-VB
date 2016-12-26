Intis-Telecom-SDK-NET-VB
=====================

The Intis telecom gateway lets you send SMS messages worldwide via its API. This program sends HTTP(s) requests and receives information as a response in JSON and/or XML. The main functions of our API include:

* sending SMS messages (including scheduling options);
* receiving status reports about messages that have been sent previously;
* requesting lists of authorised sender names;
* requesting lists of incoming SMS messages;
* requesting current balance status;
* requesting lists of databases;
* requesting lists of numbers within particular contact list;
* searching for a particular number in a stop list;
* requesting lists of templates;
* adding new templates;
* requesting monthly statistics;
* making HLR request;
* HLR запрос
* receiving HLR request statistics;
* requesting an operator’s name by phone number;

To begin using our API please [apply](https://go.intistele.com/external/client/register/) for your account at our website where you can get your login and API key.

Install
---------------------------

```
PM> Install-Package Intis
```
or
```
build Intis lib from source code
```

Usage
---------------------------

class IntisClient - The main class for SMS sending and getting API information

There are three mandatory parameters that you have to provide the constructor in order to initialize. They are:
* login - user login
* apiKey - user API key
* apiHost - API address

```vb.net

Imports Intis.SDK

Dim client = New IntisClient(login, apiKey, apiHost)
```

This class includes the following methods:
------------------------------------------

Use the `GetBalance()` method to request your balance status
```vb.net
Dim balance = client.GetBalance()

Dim amount = balance.Amount              ' Getting amount of money
Dim currency = balance.Currency          ' Getting name of currency
```

To get a list of all the contact databases you have use the function `GetPhoneBases()`
```vb.net
Dim balance = client.GetPhoneBases()

For Each one In balance
    one.BaseId                           ' Getting list ID
    one.Title                            ' Getting list name
    one.Count                            ' Getting number of contacts in list
    one.Pages                            ' Getting number of pages in list

    Dim s = one.BirthdayGreetingSettings ' Getting settings of birthday greetings
    s.Enabled                            ' Getting key that is responsible for sending greetings, 0 - do not send, 1 - send
    s.DaysBefore                         ' Getting the number of days to send greetings before
    s.Originator                         ' Getting name of sender for greeting SMS
    s.TimeToSend                         ' Getting time for sending greetings. All SMS will be sent at this time.
    s.UseLocalTime                       ' Getting variable that indicates using of local time while SMS sending.
    s.Template                           ' Getting text template that will be used in the messages.
Next
```

Our gateway supports the option of having unlimited sender’s names. To see a list of all senders’ names use the method `GetOriginators()`
```vb.net
Dim originators = client.GetOriginators()

For Each one In originators
    one.Name                            ' Getting sender name
    one.State                           ' Getting sender status
Next
```
To get a list of phone numbers from a certain contact list you need the `GetPhoneBaseItems(baseId, page)` method. For your convenience, the entire list is split into separate pages.
The parameters are: `baseId` - the ID of a particular database (mandator), and `page` - a page number in a particular database (optional).
```vb.net
Dim bases = client.GetPhoneBaseItems(baseId, page)

For Each one In bases
    one.Phone                           ' Getting subscriber number
    one.FirstName                       ' Getting subscriber first name
    one.MiddleName                      ' Getting subscriber middle name
    one.LastName                        ' Getting subscriber last name
    one.BirthDay                        ' Getting subscriber birthday
    one.Gender                          ' Getting gender of subscriber
    one.Network                         ' Getting operator of subscriber
    one.Area                            ' Getting region of subscriber
    one.Note1                           ' Getting subscriber note 1
    one.Note2                           ' Getting subscriber note 2
Next
```

To receive status info for an SMS you have already sent, use the function `GetDeliveryStatus(messageId)` where `messageId` - is an array of sent message IDs.
```vb.net
Dim status = client.GetDeliveryStatus(messageId)

For Each one In status
    one.MessageId                       ' Getting message ID
    one.MessageStatus                   ' Getting a message status
    one.CreatedAt                       ' Getting a time of message
Next
```

To send a message (to one or several recipients), use the function `SendMessage(phone, originator, text)`,
where `phone` - is a set of numbers you send your messages to,
`originator` is a sender’s name, `text` stands for the content of the message and
sendingTime - Example: 2014-05-30 14:06 (an optional parameter, it is used when it is necessary to schedule SMS messages).
An array includes `MessageSendingSuccess` if the message was successfully sent or `MessageSendingError` in case of failure.
```vb.net
Dim status = client.SendMessage(phones, originator, text, sendingTime).ToArray()

For Each one In status
	If one.IsOk Then                                     ' А flag of successful dispatch of a message
	    Dim success = CType(one, MessageSendingSuccess)
        success.Phone                                    ' Getting phone number
        success.MessageId                                ' Getting message ID
        success.Cost                                     ' Getting price for message
        success.Currency                                 ' Getting name of currency
        success.MessagesCount                            ' Getting number of message parts
    Else
	    Dim err = CType(one, MessageSendingError)
        err.Phone                                        ' Getting phone number
        err.Message                                      ' Getting error message
        err.Code                                         ' Getting code error in SMS sending
    End If
Next
```

To add a number to a stoplist run `AddToStopList(phone)` where `phone` is an individual phone number
```vb.net
Dim id = client.AddToStopList(phone) ' return ID in stop list
```

To check if a particular phone number is listed within a stop list use the function `CheckStopList(phone)`, where `phone` is an individual phone number.
```vb.net
Dim check = client.CheckStopList(phone)

check.Id                    ' Getting ID in stop list
check.Description           ' Getting reason of adding to stop list
check.TimeAddedAt           ' Getting time of adding to stop list
```

Our gateway supports the option of creating multiple templates of SMS messages. To get a list of templates use the function `GetTemplates()`.
As a response you will get a list of all the messages that a certain login has set up.
```vb.net
Dim templates = client.GetTemplates()

For Each one In templates
    one.Id                  ' Getting template ID
    one.Title               ' Getting template name
    one.template            ' Getting text of template
    one.CreatedAt           ' Getting the date and time when a particular template was created
Next
```

To add a new template to a system run the function `AddTemplate(title, template)` where `title` is a name of a template, and `template` is the text content of a template
```vb.net
Dim template = client.AddTemplate(title, text)  ' return ID user template
```

To Edit a template to a system run the function `EditTemplate(title, template)` where `title` is a name of a template, and `template` is the text content of a template
```vb.net
Dim template = client.EditTemplate(title, text) ' return ID user template
```

To get stats about messages you have sent during a particular month use the function `GetDailyStatsByMonth(year, month)` where `year` and `month` - are the particular date you need statistics for.
```vb.net
Dim stats = client.GetDailyStatsByMonth(year, month)

For Each one In stats
    one.Day                ' Getting day of month

    Dim s = one.Stats      ' Getting daily statistics
	For Each i In s
        s.State            ' Getting status of message
        s.Cost             ' Getting prices of message
        s.Currency         ' Getting name of currency
        s.Count            ' Getting number of message parts
    Next
Next
```

HLR (Home Location Register) - is the centralised database that provides detailed information regarding the GSM mobile network of every mobile user.
HLR requests let you check the availability of a single phone number or a list of numbers for further clean up of unavailable numbers from a contact list.
To perform an HLR request, our system supports the function `MakeHLRRequest(phones)` where `phones` is the array of phone numbers.
```vb.net
Dim hlrResponse = client.MakeHlrRequest(phones)

For Each one In hlrResponse
    one.Id                    ' Getting ID
    one.Destination           ' Getting recipient
    one.IMSI                  ' Getting IMSI
    one.MCC                   ' Getting MCC of subscriber
    one.MNC                   ' Getting MNC of subscriber
    one.OriginalCountryName   ' Getting the original name of the subscriber's country
    one.OriginalCountryCode   ' Getting the original code of the subscriber's country
    one.OriginalNetworkName   ' Getting the original name of the subscriber's operator
    one.OriginalNetworkPrefix ' Getting the original prefix of the subscriber's operator
    one.PortedCountryName     ' Getting name of country if subscriber's phone number is ported
    one.PortedCountryPrefix   ' Getting prefix of country if subscriber's phone number is ported
    one.PortedNetworkName     ' Getting name of operator if subscriber's phone number is ported
    one.PortedNetworkPrefix   ' Getting prefix of operator if subscriber's phone number is ported
    one.RoamingCountryName    ' Getting name of country if the subscriber is in roaming
    one.RoamingCountryPrefix  ' Getting prefix of country if the subscriber is in roaming
    one.RoamingNetworkName    ' Getting name of operator if the subscriber is in roaming
    one.RoamingNetworkPrefix  ' Getting prefix of operator if the subscriber is in roaming
    one.Status                ' Getting status of subscriber
    one.PricePerMessage       ' Getting price for message
    one.IsInRoaming           ' Determining if the subscriber is in roaming
    one.IsPorted              ' Identification of ported number
Next
```

Besides, you can can get HLR requests statistics regarding a certain time range. To do that,  use the function `GetHlrStats(from, to)` where `from` and `to` are the beginning and end of a time period.
```vb.net
Dim hlrStatItem = client.GetHlrStats(from, to)

For Each one In hlrStatItem
	one.Id                    ' Getting ID
	one.Phone                 ' Getting phone number
	one.MessageId             ' Getting message ID
	one.TotalPrice            ' Getting final price of request
	one.Destination           ' Getting recipient
	one.IMSI                  ' Getting IMSI
	one.MCC                   ' Getting MCC of subscriber
	one.MNC                   ' Getting MNC of subscriber
	one.OriginalCountryName   ' Getting the original name of the subscriber's country
	one.OriginalCountryCode   ' Getting the original code of the subscriber's country
	one.OriginalNetworkName   ' Getting the original name of the subscriber's operator
	one.OriginalNetworkPrefix ' Getting the original prefix of the subscriber's operator
	one.PortedCountryName     ' Getting name of country if subscriber's phone number is ported
	one.PortedCountryPrefix   ' Getting prefix of country if subscriber's phone number is ported
	one.PortedNetworkName     ' Getting name of operator if subscriber's phone number is ported
	one.PortedNetworkPrefix   ' Getting prefix of operator if subscriber's phone number is ported
	one.RoamingCountryName    ' Getting name of country if the subscriber is in roaming
	one.RoamingCountryPrefix  ' Getting prefix of country if the subscriber is in roaming
	one.RoamingNetworkName    ' Getting name of operator if the subscriber is in roaming
	one.RoamingNetworkPrefix  ' Getting prefix of operator if the subscriber is in roaming
	one.Status                ' Getting status of subscriber
	one.PricePerMessage       ' Getting price for message
	one.isInRoaming           ' Determining if the subscriber is in roaming
	one.isPorted              ' Identification of ported number
	one.RequestId             ' Getting request ID
	one.RequestTime           ' Getting time of request
Next
```

To get information regarding which mobile network a certain phone number belongs to, use the function `GetNetworkByPhone(phone)`, where `phone` is a phone number.
```vb.net
Dim network = client.GetNetworkByPhone(phone)

network.Title                 ' Getting operator of subscriber
```

Please bear in mind that this method has less accuracy than HLR requests as it uses our internal database to check which mobile operator a phone numbers belongs to.

To get a list of incoming messages please use the function `GetIncomingMessages(date)`, where `date` stands for a particular day in YYYY-mm-dd format.
Or use the function `GetIncomingMessages(from, to)`, where 
from - date of start in the format YYYY-MM-DD HH:II:SS (Example: 2014-05-01 14:06:00) and
to - date of end in the format YYYY-MM-DD HH:II:SS (Example: 2014-05-30 23:59:59)
```vb.net
Dim messages = client.GetIncomingMessages(data)

For Each one In messages
    one.MessageId            ' Getting message ID
    one.Originator           ' Getting sender name of the incoming message
    one.Prefix               ' Getting prefix of the incoming message
    one.ReceivedAt           ' Getting date of the incoming message
    one.Text                 ' Getting text of the incoming message
	one.Destination          ' Get message destination
Next
```
