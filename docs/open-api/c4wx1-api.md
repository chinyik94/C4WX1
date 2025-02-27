---
title: C4WX1.API v1.0.0
language_tabs:
  - shell: CURL
language_clients:
  - shell: ""
toc_footers: []
includes: []
search: true
highlight_theme: darkula
headingLevel: 2

---

<!-- Generator: Widdershins v4.0.1 -->

<h1 id="c4wx1-api">C4WX1.API v1.0.0</h1>

> Scroll down for code samples, example requests and responses. Select a language for code samples from the tabs above or the mobile navigation menu.

Base URLs:

* <a href="https://localhost:7055">https://localhost:7055</a>

# Authentication

- HTTP Authentication, scheme: Bearer Enter a JWT token to authorize the requests...

<h1 id="c4wx1-api-sysconfig">Sysconfig</h1>

## C4WX1APIFeaturesSysConfigUpdateUpdate

<a id="opIdC4WX1APIFeaturesSysConfigUpdateUpdate"></a>

> Code samples

```shell
curl --request PUT \
  --url https://localhost:7055/api/sysconfig \
  --header 'Accept: application/problem+json' \
  --header 'Content-Type: application/json' \
  --data '[{"ConfigName":"Config1","ConfigValue":"Value1","UserID":1},{"ConfigName":"Config2","ConfigValue":"Value2","UserID":1}]'
```

`PUT /api/sysconfig`

*Update SysConfig*

Update one or multiple existing SysConfigs

> Body parameter

```json
[
  {
    "ConfigName": "Config1",
    "ConfigValue": "Value1",
    "UserID": 1
  },
  {
    "ConfigName": "Config2",
    "ConfigValue": "Value2",
    "UserID": 1
  }
]
```

<h3 id="c4wx1apifeaturessysconfigupdateupdate-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[C4WX1APIFeaturesSysConfigDtosUpdateSysConfigDto](#schemac4wx1apifeaturessysconfigdtosupdatesysconfigdto)|true|none|

> Example responses

> 500 Response

```json
{
  "Status": "Internal Server Error!",
  "Code": 500,
  "Reason": "Something unexpected has happened",
  "Note": "See application log for stack trace."
}
```

<h3 id="c4wx1apifeaturessysconfigupdateupdate-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|204|[No Content](https://tools.ietf.org/html/rfc7231#section-6.3.5)|SysConfig updated successfully|None|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|SysConfig not found|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## C4WX1APIFeaturesSysConfigGetGetList

<a id="opIdC4WX1APIFeaturesSysConfigGetGetList"></a>

> Code samples

```shell
curl --request GET \
  --url https://localhost:7055/api/sysconfig \
  --header 'Accept: application/json'
```

`GET /api/sysconfig`

*Get SysConfig List*

Get a filtered, paged and sorted list of SysConfigs

<h3 id="c4wx1apifeaturessysconfiggetgetlist-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|ConfigName|query|string|false|none|
|ConfigValue|query|string|false|none|
|PageIndex|query|integer(int32)|false|none|
|PageSize|query|integer(int32)|false|none|
|OrderBy|query|string|false|none|

> Example responses

> 200 Response

```json
[
  {
    "ConfigName": "string",
    "ConfigValue": "string",
    "ModifiedDate": "2019-08-24T14:15:22Z",
    "ModifiedBy_FK": 0,
    "IsConfigurable": true,
    "Description": "string"
  }
]
```

<h3 id="c4wx1apifeaturessysconfiggetgetlist-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|SysConfig List retrieved successfully|Inline|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<h3 id="c4wx1apifeaturessysconfiggetgetlist-responseschema">Response Schema</h3>

Status Code **200**

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[[C4WX1APIFeaturesSysConfigDtosSysConfigDto](#schemac4wx1apifeaturessysconfigdtossysconfigdto)]|false|none|none|
|» ConfigName|string|false|none|none|
|» ConfigValue|string¦null|false|none|none|
|» ModifiedDate|string(date-time)¦null|false|none|none|
|» ModifiedBy_FK|integer(int32)¦null|false|none|none|
|» IsConfigurable|boolean¦null|false|none|none|
|» Description|string¦null|false|none|none|

<aside class="success">
This operation does not require authentication
</aside>

## C4WX1APIFeaturesSysConfigCreateCreate

<a id="opIdC4WX1APIFeaturesSysConfigCreateCreate"></a>

> Code samples

```shell
curl --request POST \
  --url https://localhost:7055/api/sysconfig \
  --header 'Accept: application/problem+json' \
  --header 'Content-Type: application/json' \
  --data '{"ConfigName":"Config Name","ConfigValue":"Config Value","IsConfigurable":false,"Description":"Description"}'
```

`POST /api/sysconfig`

*Create SysConfig*

Create a new SysConfig

> Body parameter

```json
{
  "ConfigName": "Config Name",
  "ConfigValue": "Config Value",
  "IsConfigurable": false,
  "Description": "Description"
}
```

<h3 id="c4wx1apifeaturessysconfigcreatecreate-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[C4WX1APIFeaturesSysConfigDtosCreateSysConfigDto](#schemac4wx1apifeaturessysconfigdtoscreatesysconfigdto)|true|none|

> Example responses

> 500 Response

```json
{
  "Status": "Internal Server Error!",
  "Code": 500,
  "Reason": "Something unexpected has happened",
  "Note": "See application log for stack trace."
}
```

<h3 id="c4wx1apifeaturessysconfigcreatecreate-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|204|[No Content](https://tools.ietf.org/html/rfc7231#section-6.3.5)|SysConfig created successfully|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## C4WX1APIFeaturesSysConfigGetGet

<a id="opIdC4WX1APIFeaturesSysConfigGetGet"></a>

> Code samples

```shell
curl --request GET \
  --url https://localhost:7055/api/sysconfig/config-name/string \
  --header 'Accept: application/json'
```

`GET /api/sysconfig/config-name/{configName}`

*Get SysConfig*

Get SysConfig by its ConfigName

<h3 id="c4wx1apifeaturessysconfiggetget-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|configName|path|string|true|none|

> Example responses

> 200 Response

```json
{
  "ConfigName": "string",
  "ConfigValue": "string",
  "ModifiedDate": "2019-08-24T14:15:22Z",
  "ModifiedBy_FK": 0,
  "IsConfigurable": true,
  "Description": "string"
}
```

<h3 id="c4wx1apifeaturessysconfiggetget-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|SysConfig retrieved successfully|[C4WX1APIFeaturesSysConfigDtosSysConfigDto](#schemac4wx1apifeaturessysconfigdtossysconfigdto)|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|SysConfig not found|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## C4WX1APIFeaturesSysConfigGetGetAllList

<a id="opIdC4WX1APIFeaturesSysConfigGetGetAllList"></a>

> Code samples

```shell
curl --request GET \
  --url https://localhost:7055/api/sysconfig/all \
  --header 'Accept: application/json'
```

`GET /api/sysconfig/all`

*Get All SysConfig*

Get all SysConfigs

> Example responses

> 200 Response

```json
[
  {
    "ConfigName": "string",
    "ConfigValue": "string",
    "ModifiedDate": "2019-08-24T14:15:22Z",
    "ModifiedBy_FK": 0,
    "IsConfigurable": true,
    "Description": "string"
  }
]
```

<h3 id="c4wx1apifeaturessysconfiggetgetalllist-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|SysConfig List retrieved successfully|Inline|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<h3 id="c4wx1apifeaturessysconfiggetgetalllist-responseschema">Response Schema</h3>

Status Code **200**

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[[C4WX1APIFeaturesSysConfigDtosSysConfigDto](#schemac4wx1apifeaturessysconfigdtossysconfigdto)]|false|none|none|
|» ConfigName|string|false|none|none|
|» ConfigValue|string¦null|false|none|none|
|» ModifiedDate|string(date-time)¦null|false|none|none|
|» ModifiedBy_FK|integer(int32)¦null|false|none|none|
|» IsConfigurable|boolean¦null|false|none|none|
|» Description|string¦null|false|none|none|

<aside class="success">
This operation does not require authentication
</aside>

## C4WX1APIFeaturesSysConfigGetGetCount

<a id="opIdC4WX1APIFeaturesSysConfigGetGetCount"></a>

> Code samples

```shell
curl --request GET \
  --url https://localhost:7055/api/sysconfig/count \
  --header 'Accept: application/json'
```

`GET /api/sysconfig/count`

*Get SysConfig Count*

Get the number of SysConfigs

> Example responses

> 200 Response

```json
0
```

<h3 id="c4wx1apifeaturessysconfiggetgetcount-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Number of SysConfigs retrieved successfully|integer|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

<h1 id="c4wx1-api-chat">Chat</h1>

## C4WX1APIFeaturesChatGetGetById

<a id="opIdC4WX1APIFeaturesChatGetGetById"></a>

> Code samples

```shell
curl --request GET \
  --url https://localhost:7055/api/chat/0 \
  --header 'Accept: application/json'
```

`GET /api/chat/{id}`

*Get Chat*

Get Chat by its ID

<h3 id="c4wx1apifeatureschatgetgetbyid-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|integer(int32)|true|none|

> Example responses

> 200 Response

```json
{
  "ChatID": 0,
  "Comment": "string",
  "Attachment": "string",
  "Attachment_Physical": "string",
  "ParentID_FK": 0,
  "PatientID_FK": 0,
  "CreatedDate": "2019-08-24T14:15:22Z",
  "CreatedBy_FK": 0,
  "IsDeleted": true,
  "Family": true,
  "UserData": {
    "UserId": 0,
    "Firstname": "string",
    "Lastname": "string",
    "Photo": "string"
  },
  "PatientData": {
    "PatientID": 0,
    "Firstname": "string",
    "Lastname": "string",
    "Photo": "string"
  },
  "CommentList": [
    {
      "ChatID": 0,
      "Comment": "string",
      "Attachment": "string",
      "Attachment_Physical": "string",
      "ParentID_FK": 0,
      "PatientID_FK": 0,
      "CreatedDate": "2019-08-24T14:15:22Z",
      "CreatedBy_FK": 0,
      "IsDeleted": true,
      "Family": true,
      "UserData": {
        "UserId": 0,
        "Firstname": "string",
        "Lastname": "string",
        "Photo": "string"
      },
      "PatientData": {
        "PatientID": 0,
        "Firstname": "string",
        "Lastname": "string",
        "Photo": "string"
      },
      "CommentList": []
    }
  ]
}
```

<h3 id="c4wx1apifeatureschatgetgetbyid-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Chat retrieved successfully|[C4WX1APIFeaturesChatDtosChatDto](#schemac4wx1apifeatureschatdtoschatdto)|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## C4WX1APIFeaturesChatDeleteDelete

<a id="opIdC4WX1APIFeaturesChatDeleteDelete"></a>

> Code samples

```shell
curl --request DELETE \
  --url https://localhost:7055/api/chat/0 \
  --header 'Accept: application/problem+json' \
  --header 'Content-Type: */*' \
  --data '{"UserId":0}'
```

`DELETE /api/chat/{id}`

*Delete Chat*

Delete an existing Chat

> Body parameter

```json
{
  "UserId": 0
}
```

<h3 id="c4wx1apifeatureschatdeletedelete-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|integer(int32)|true|none|
|body|body|[C4WX1APIFeaturesSharedDtosDeleteByIdDto](#schemac4wx1apifeaturesshareddtosdeletebyiddto)|true|none|

> Example responses

> 500 Response

```json
{
  "Status": "Internal Server Error!",
  "Code": 500,
  "Reason": "Something unexpected has happened",
  "Note": "See application log for stack trace."
}
```

<h3 id="c4wx1apifeatureschatdeletedelete-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|204|[No Content](https://tools.ietf.org/html/rfc7231#section-6.3.5)|Chat deleted successfully|None|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Chat not found|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## C4WX1APIFeaturesChatGetGetCanLoadMore

<a id="opIdC4WX1APIFeaturesChatGetGetCanLoadMore"></a>

> Code samples

```shell
curl --request GET \
  --url https://localhost:7055/api/chat/can-load-more \
  --header 'Accept: application/json'
```

`GET /api/chat/can-load-more`

*Get Can Load More Chat*

Check if there are more chats to load

<h3 id="c4wx1apifeatureschatgetgetcanloadmore-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|Min|query|integer(int32)|false|none|
|PatientId|query|integer(int32)|false|none|
|UserId|query|integer(int32)|false|none|

> Example responses

> 200 Response

```json
true
```

<h3 id="c4wx1apifeatureschatgetgetcanloadmore-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|boolean|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## C4WX1APIFeaturesChatGetGetLatestList

<a id="opIdC4WX1APIFeaturesChatGetGetLatestList"></a>

> Code samples

```shell
curl --request GET \
  --url 'https://localhost:7055/api/chat/latest?Count=0' \
  --header 'Accept: application/json'
```

`GET /api/chat/latest`

*Get Latest Chat List*

Get the latest Chat list

<h3 id="c4wx1apifeatureschatgetgetlatestlist-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|ChatID|query|integer(int32)|false|none|
|PatientID|query|integer(int32)|false|none|
|UserID|query|integer(int32)|false|none|
|Count|query|integer(int32)|true|none|
|Family|query|boolean|false|none|

> Example responses

> 200 Response

```json
[
  {
    "ChatID": 0,
    "Comment": "string",
    "Attachment": "string",
    "Attachment_Physical": "string",
    "ParentID_FK": 0,
    "PatientID_FK": 0,
    "CreatedDate": "2019-08-24T14:15:22Z",
    "CreatedBy_FK": 0,
    "IsDeleted": true,
    "Family": true,
    "UserData": {
      "UserId": 0,
      "Firstname": "string",
      "Lastname": "string",
      "Photo": "string"
    },
    "PatientData": {
      "PatientID": 0,
      "Firstname": "string",
      "Lastname": "string",
      "Photo": "string"
    },
    "CommentList": [
      {}
    ]
  }
]
```

<h3 id="c4wx1apifeatureschatgetgetlatestlist-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Chat list retrieved successfully|Inline|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<h3 id="c4wx1apifeatureschatgetgetlatestlist-responseschema">Response Schema</h3>

Status Code **200**

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[[C4WX1APIFeaturesChatDtosChatDto](#schemac4wx1apifeatureschatdtoschatdto)]|false|none|none|
|» ChatID|integer(int32)|false|none|none|
|» Comment|string¦null|false|none|none|
|» Attachment|string¦null|false|none|none|
|» Attachment_Physical|string¦null|false|none|none|
|» ParentID_FK|integer(int32)¦null|false|none|none|
|» PatientID_FK|integer(int32)¦null|false|none|none|
|» CreatedDate|string(date-time)|false|none|none|
|» CreatedBy_FK|integer(int32)|false|none|none|
|» IsDeleted|boolean|false|none|none|
|» Family|boolean¦null|false|none|none|
|» UserData|[C4WX1APIFeaturesChatDtosChatUserDto](#schemac4wx1apifeatureschatdtoschatuserdto)¦null|false|none|none|
|»» UserId|integer(int32)|false|none|none|
|»» Firstname|string|false|none|none|
|»» Lastname|string|false|none|none|
|»» Photo|string¦null|false|none|none|
|» PatientData|[C4WX1APIFeaturesChatDtosChatPatientDto](#schemac4wx1apifeatureschatdtoschatpatientdto)¦null|false|none|none|
|»» PatientID|integer(int32)|false|none|none|
|»» Firstname|string|false|none|none|
|»» Lastname|string|false|none|none|
|»» Photo|string¦null|false|none|none|
|» CommentList|[[C4WX1APIFeaturesChatDtosChatDto](#schemac4wx1apifeatureschatdtoschatdto)]|false|none|none|

<aside class="success">
This operation does not require authentication
</aside>

## C4WX1APIFeaturesChatGetGetPreviousList

<a id="opIdC4WX1APIFeaturesChatGetGetPreviousList"></a>

> Code samples

```shell
curl --request GET \
  --url 'https://localhost:7055/api/chat/previous?Count=0' \
  --header 'Accept: application/json'
```

`GET /api/chat/previous`

*Get Previous Chat List*

Get the previous Chat list

<h3 id="c4wx1apifeatureschatgetgetpreviouslist-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|ChatID|query|integer(int32)|false|none|
|PatientID|query|integer(int32)|false|none|
|UserID|query|integer(int32)|false|none|
|Count|query|integer(int32)|true|none|
|Family|query|boolean|false|none|

> Example responses

> 200 Response

```json
[
  {
    "ChatID": 0,
    "Comment": "string",
    "Attachment": "string",
    "Attachment_Physical": "string",
    "ParentID_FK": 0,
    "PatientID_FK": 0,
    "CreatedDate": "2019-08-24T14:15:22Z",
    "CreatedBy_FK": 0,
    "IsDeleted": true,
    "Family": true,
    "UserData": {
      "UserId": 0,
      "Firstname": "string",
      "Lastname": "string",
      "Photo": "string"
    },
    "PatientData": {
      "PatientID": 0,
      "Firstname": "string",
      "Lastname": "string",
      "Photo": "string"
    },
    "CommentList": [
      {}
    ]
  }
]
```

<h3 id="c4wx1apifeatureschatgetgetpreviouslist-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Chat list retrieved successfully|Inline|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<h3 id="c4wx1apifeatureschatgetgetpreviouslist-responseschema">Response Schema</h3>

Status Code **200**

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[[C4WX1APIFeaturesChatDtosChatDto](#schemac4wx1apifeatureschatdtoschatdto)]|false|none|none|
|» ChatID|integer(int32)|false|none|none|
|» Comment|string¦null|false|none|none|
|» Attachment|string¦null|false|none|none|
|» Attachment_Physical|string¦null|false|none|none|
|» ParentID_FK|integer(int32)¦null|false|none|none|
|» PatientID_FK|integer(int32)¦null|false|none|none|
|» CreatedDate|string(date-time)|false|none|none|
|» CreatedBy_FK|integer(int32)|false|none|none|
|» IsDeleted|boolean|false|none|none|
|» Family|boolean¦null|false|none|none|
|» UserData|[C4WX1APIFeaturesChatDtosChatUserDto](#schemac4wx1apifeatureschatdtoschatuserdto)¦null|false|none|none|
|»» UserId|integer(int32)|false|none|none|
|»» Firstname|string|false|none|none|
|»» Lastname|string|false|none|none|
|»» Photo|string¦null|false|none|none|
|» PatientData|[C4WX1APIFeaturesChatDtosChatPatientDto](#schemac4wx1apifeatureschatdtoschatpatientdto)¦null|false|none|none|
|»» PatientID|integer(int32)|false|none|none|
|»» Firstname|string|false|none|none|
|»» Lastname|string|false|none|none|
|»» Photo|string¦null|false|none|none|
|» CommentList|[[C4WX1APIFeaturesChatDtosChatDto](#schemac4wx1apifeatureschatdtoschatdto)]|false|none|none|

<aside class="success">
This operation does not require authentication
</aside>

## C4WX1APIFeaturesChatCreateCreate

<a id="opIdC4WX1APIFeaturesChatCreateCreate"></a>

> Code samples

```shell
curl --request POST \
  --url https://localhost:7055/api/chat \
  --header 'Accept: application/json' \
  --header 'Content-Type: application/json' \
  --data '{"Attachment":"Attachment","Attachment_Physical":"Attachment_Physical","CreatedBy_FK":1,"ParentID_FK":1,"PatientID_FK":1,"Comment":"Comment","Family":true}'
```

`POST /api/chat`

*Create Chat*

Create a new Chat

> Body parameter

```json
{
  "Attachment": "Attachment",
  "Attachment_Physical": "Attachment_Physical",
  "CreatedBy_FK": 1,
  "ParentID_FK": 1,
  "PatientID_FK": 1,
  "Comment": "Comment",
  "Family": true
}
```

<h3 id="c4wx1apifeatureschatcreatecreate-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[C4WX1APIFeaturesChatDtosCreateChatDto](#schemac4wx1apifeatureschatdtoscreatechatdto)|true|none|

> Example responses

> 200 Response

```json
{
  "ChatID": 0,
  "Comment": "string",
  "Attachment": "string",
  "Attachment_Physical": "string",
  "ParentID_FK": 0,
  "PatientID_FK": 0,
  "CreatedDate": "2019-08-24T14:15:22Z",
  "CreatedBy_FK": 0,
  "IsDeleted": true,
  "Family": true,
  "UserData": {
    "UserId": 0,
    "Firstname": "string",
    "Lastname": "string",
    "Photo": "string"
  },
  "PatientData": {
    "PatientID": 0,
    "Firstname": "string",
    "Lastname": "string",
    "Photo": "string"
  },
  "CommentList": [
    {
      "ChatID": 0,
      "Comment": "string",
      "Attachment": "string",
      "Attachment_Physical": "string",
      "ParentID_FK": 0,
      "PatientID_FK": 0,
      "CreatedDate": "2019-08-24T14:15:22Z",
      "CreatedBy_FK": 0,
      "IsDeleted": true,
      "Family": true,
      "UserData": {
        "UserId": 0,
        "Firstname": "string",
        "Lastname": "string",
        "Photo": "string"
      },
      "PatientData": {
        "PatientID": 0,
        "Firstname": "string",
        "Lastname": "string",
        "Photo": "string"
      },
      "CommentList": []
    }
  ]
}
```

<h3 id="c4wx1apifeatureschatcreatecreate-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Chat created successfully|[C4WX1APIFeaturesChatDtosChatDto](#schemac4wx1apifeatureschatdtoschatdto)|
|400|[Bad Request](https://tools.ietf.org/html/rfc7231#section-6.5.1)|Invalid request|[FastEndpointsErrorResponse](#schemafastendpointserrorresponse)|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Chat not found|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

<h1 id="c4wx1-api-care-plan-sub-goal">Care-Plan-Sub-Goal</h1>

## C4WX1APIFeaturesCarePlanSubGoalUpdateUpdate

<a id="opIdC4WX1APIFeaturesCarePlanSubGoalUpdateUpdate"></a>

> Code samples

```shell
curl --request PUT \
  --url https://localhost:7055/api/care-plan-sub-goal/0 \
  --header 'Accept: application/problem+json' \
  --header 'Content-Type: application/json' \
  --data '{"CarePlanSubID_FK":1,"CarePlanSubGoalName":"care plan sub goal","UserId":1}'
```

`PUT /api/care-plan-sub-goal/{carePlanSubGoalID}`

*Update Care Plan Sub Goal*

Update a new Care Plan Sub Goal

> Body parameter

```json
{
  "CarePlanSubID_FK": 1,
  "CarePlanSubGoalName": "care plan sub goal",
  "UserId": 1
}
```

<h3 id="c4wx1apifeaturescareplansubgoalupdateupdate-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|carePlanSubGoalID|path|integer(int32)|true|none|
|body|body|[C4WX1APIFeaturesCarePlanSubGoalDtosUpdateCarePlanSubGoalDto](#schemac4wx1apifeaturescareplansubgoaldtosupdatecareplansubgoaldto)|true|none|

> Example responses

> 500 Response

```json
{
  "Status": "Internal Server Error!",
  "Code": 500,
  "Reason": "Something unexpected has happened",
  "Note": "See application log for stack trace."
}
```

<h3 id="c4wx1apifeaturescareplansubgoalupdateupdate-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|204|[No Content](https://tools.ietf.org/html/rfc7231#section-6.3.5)|Care Plan Sub Goal updated successfully|None|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Care Plan Sub Goal not found|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## C4WX1APIFeaturesCarePlanSubGoalGetGetById

<a id="opIdC4WX1APIFeaturesCarePlanSubGoalGetGetById"></a>

> Code samples

```shell
curl --request GET \
  --url https://localhost:7055/api/care-plan-sub-goal/0 \
  --header 'Accept: application/json'
```

`GET /api/care-plan-sub-goal/{id}`

*Get Care Plan Sub Goal*

Get a Care Plan Sub Goal by its ID

<h3 id="c4wx1apifeaturescareplansubgoalgetgetbyid-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|integer(int32)|true|none|

> Example responses

> 200 Response

```json
{
  "CarePlanSubGoalID": 0,
  "ScoreTypeID": 0,
  "Score1": 0,
  "Score2": 0,
  "CarePlanSubGoalName": "string",
  "IsDeleted": true,
  "CanDelete": true
}
```

<h3 id="c4wx1apifeaturescareplansubgoalgetgetbyid-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Care Plan Sub Goal retrieved successfully|[C4WX1APIFeaturesCarePlanSubGoalDtosCarePlanSubGoalDto](#schemac4wx1apifeaturescareplansubgoaldtoscareplansubgoaldto)|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Care Plan Sub Goal not found|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## C4WX1APIFeaturesCarePlanSubGoalDeleteDelete

<a id="opIdC4WX1APIFeaturesCarePlanSubGoalDeleteDelete"></a>

> Code samples

```shell
curl --request DELETE \
  --url https://localhost:7055/api/care-plan-sub-goal/0 \
  --header 'Accept: application/problem+json' \
  --header 'Content-Type: */*' \
  --data '{"UserId":0}'
```

`DELETE /api/care-plan-sub-goal/{id}`

*Delete Care Plan Sub Goal*

Delete a Care Plan Sub Goal by its ID

> Body parameter

```json
{
  "UserId": 0
}
```

<h3 id="c4wx1apifeaturescareplansubgoaldeletedelete-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|integer(int32)|true|none|
|body|body|[C4WX1APIFeaturesSharedDtosDeleteByIdDto](#schemac4wx1apifeaturesshareddtosdeletebyiddto)|true|none|

> Example responses

> 500 Response

```json
{
  "Status": "Internal Server Error!",
  "Code": 500,
  "Reason": "Something unexpected has happened",
  "Note": "See application log for stack trace."
}
```

<h3 id="c4wx1apifeaturescareplansubgoaldeletedelete-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|204|[No Content](https://tools.ietf.org/html/rfc7231#section-6.3.5)|No Content|None|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Care Plan Sub Goal not found|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## C4WX1APIFeaturesCarePlanSubGoalGetGetCount

<a id="opIdC4WX1APIFeaturesCarePlanSubGoalGetGetCount"></a>

> Code samples

```shell
curl --request GET \
  --url https://localhost:7055/api/care-plan-sub-goal/count \
  --header 'Accept: application/json'
```

`GET /api/care-plan-sub-goal/count`

*Get Care Plan Sub Goal Count*

Get Care Plan Sub Goal Count

> Example responses

> 200 Response

```json
0
```

<h3 id="c4wx1apifeaturescareplansubgoalgetgetcount-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Care Plan Sub Goal Count retrieved successfully|integer|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## C4WX1APIFeaturesCarePlanSubGoalGetGetList

<a id="opIdC4WX1APIFeaturesCarePlanSubGoalGetGetList"></a>

> Code samples

```shell
curl --request GET \
  --url https://localhost:7055/api/care-plan-sub-goal \
  --header 'Accept: application/json'
```

`GET /api/care-plan-sub-goal`

*Get Care Plan Sub Goal List*

Get a paged and sorted Care Plan Sub Goal List

<h3 id="c4wx1apifeaturescareplansubgoalgetgetlist-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|PageIndex|query|integer(int32)|false|none|
|PageSize|query|integer(int32)|false|none|
|OrderBy|query|string|false|none|

> Example responses

> 200 Response

```json
[
  {
    "CarePlanSubGoalID": 0,
    "ScoreTypeID": 0,
    "Score1": 0,
    "Score2": 0,
    "CarePlanSubGoalName": "string",
    "IsDeleted": true,
    "CanDelete": true
  }
]
```

<h3 id="c4wx1apifeaturescareplansubgoalgetgetlist-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Care Plan Sub Goal List retrieved successfully|Inline|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<h3 id="c4wx1apifeaturescareplansubgoalgetgetlist-responseschema">Response Schema</h3>

Status Code **200**

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[[C4WX1APIFeaturesCarePlanSubGoalDtosCarePlanSubGoalDto](#schemac4wx1apifeaturescareplansubgoaldtoscareplansubgoaldto)]|false|none|none|
|» CarePlanSubGoalID|integer(int32)|false|none|none|
|» ScoreTypeID|integer(int32)¦null|false|none|none|
|» Score1|number(decimal)¦null|false|none|none|
|» Score2|number(decimal)¦null|false|none|none|
|» CarePlanSubGoalName|string¦null|false|none|none|
|» IsDeleted|boolean¦null|false|none|none|
|» CanDelete|boolean|false|none|none|

<aside class="success">
This operation does not require authentication
</aside>

## C4WX1APIFeaturesCarePlanSubGoalCreateCreate

<a id="opIdC4WX1APIFeaturesCarePlanSubGoalCreateCreate"></a>

> Code samples

```shell
curl --request POST \
  --url https://localhost:7055/api/care-plan-sub-goal \
  --header 'Accept: application/problem+json' \
  --header 'Content-Type: application/json' \
  --data '{"CarePlanSubID_FK":1,"CarePlanSubGoalName":"care plan sub goal","UserId":1}'
```

`POST /api/care-plan-sub-goal`

*Create Care Plan Sub Goal*

Create a new Care Plan Sub Goal

> Body parameter

```json
{
  "CarePlanSubID_FK": 1,
  "CarePlanSubGoalName": "care plan sub goal",
  "UserId": 1
}
```

<h3 id="c4wx1apifeaturescareplansubgoalcreatecreate-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[C4WX1APIFeaturesCarePlanSubGoalDtosCreateCarePlanSubGoalDto](#schemac4wx1apifeaturescareplansubgoaldtoscreatecareplansubgoaldto)|true|none|

> Example responses

> 500 Response

```json
{
  "Status": "Internal Server Error!",
  "Code": 500,
  "Reason": "Something unexpected has happened",
  "Note": "See application log for stack trace."
}
```

<h3 id="c4wx1apifeaturescareplansubgoalcreatecreate-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|204|[No Content](https://tools.ietf.org/html/rfc7231#section-6.3.5)|Care Plan Sub Goal created successfully|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

<h1 id="c4wx1-api-c4w-image">C4w-Image</h1>

## C4WX1APIFeaturesC4WImageUpdateUpdate

<a id="opIdC4WX1APIFeaturesC4WImageUpdateUpdate"></a>

> Code samples

```shell
curl --request PUT \
  --url https://localhost:7055/api/c4w-image/0 \
  --header 'Accept: application/problem+json' \
  --header 'Content-Type: application/json' \
  --data '{"WoundImageName":"wound image name","WoundImageData":"wound image data","WoundBedImageName":"wound bed image name","WoundBedImageData":"wound bed image data","TissueImageName":"tissue image name","TissueImageData":"tissue image data","DepthImageName":"depth image name","DepthImageData":"depth image data","UserId":1}'
```

`PUT /api/c4w-image/{c4wImageId}`

*Update C4W Image*

Update an existing C4W Image

> Body parameter

```json
{
  "WoundImageName": "wound image name",
  "WoundImageData": "wound image data",
  "WoundBedImageName": "wound bed image name",
  "WoundBedImageData": "wound bed image data",
  "TissueImageName": "tissue image name",
  "TissueImageData": "tissue image data",
  "DepthImageName": "depth image name",
  "DepthImageData": "depth image data",
  "UserId": 1
}
```

<h3 id="c4wx1apifeaturesc4wimageupdateupdate-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|c4wImageId|path|integer(int32)|true|none|
|body|body|[C4WX1APIFeaturesC4WImageDtosUpdateC4WImageDto](#schemac4wx1apifeaturesc4wimagedtosupdatec4wimagedto)|true|none|

> Example responses

> 500 Response

```json
{
  "Status": "Internal Server Error!",
  "Code": 500,
  "Reason": "Something unexpected has happened",
  "Note": "See application log for stack trace."
}
```

<h3 id="c4wx1apifeaturesc4wimageupdateupdate-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|204|[No Content](https://tools.ietf.org/html/rfc7231#section-6.3.5)|C4W Image updated successfully|None|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|C4W Image not found|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## C4WX1APIFeaturesC4WImageGetGetById

<a id="opIdC4WX1APIFeaturesC4WImageGetGetById"></a>

> Code samples

```shell
curl --request GET \
  --url https://localhost:7055/api/c4w-image/0 \
  --header 'Accept: application/json'
```

`GET /api/c4w-image/{id}`

*Get C4W Image*

Get a C4W Image by its ID

<h3 id="c4wx1apifeaturesc4wimagegetgetbyid-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|integer(int32)|true|none|

> Example responses

> 200 Response

```json
{
  "C4WImageId": 0,
  "WoundImageName": "string",
  "WoundImageData": "string",
  "WoundBedImageName": "string",
  "WoundBedImageData": "string",
  "TissueImageName": "string",
  "TissueImageData": "string",
  "DepthImageName": "string",
  "DepthImageData": "string",
  "IsDeleted": true,
  "CreatedDate": "2019-08-24T14:15:22Z",
  "CreatedBy_FK": 0,
  "ModifiedDate": "2019-08-24T14:15:22Z"
}
```

<h3 id="c4wx1apifeaturesc4wimagegetgetbyid-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|C4W Image retrieved successfully|[C4WX1APIFeaturesC4WImageDtosC4WImageDto](#schemac4wx1apifeaturesc4wimagedtosc4wimagedto)|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|C4W Image not found|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## C4WX1APIFeaturesC4WImageGetGetCount

<a id="opIdC4WX1APIFeaturesC4WImageGetGetCount"></a>

> Code samples

```shell
curl --request GET \
  --url 'https://localhost:7055/api/c4w-image/count?FromDate=2019-08-24T14%3A15%3A22Z&ToDate=2019-08-24T14%3A15%3A22Z' \
  --header 'Accept: application/json'
```

`GET /api/c4w-image/count`

*Get C4W Image Count*

Get C4W Image Count based on its CreatedDate

<h3 id="c4wx1apifeaturesc4wimagegetgetcount-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|FromDate|query|string(date-time)|true|none|
|ToDate|query|string(date-time)|true|none|

> Example responses

> 200 Response

```json
0
```

<h3 id="c4wx1apifeaturesc4wimagegetgetcount-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|C4W Image Count retrieved successfully|integer|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## C4WX1APIFeaturesC4WImageGetGetList

<a id="opIdC4WX1APIFeaturesC4WImageGetGetList"></a>

> Code samples

```shell
curl --request GET \
  --url 'https://localhost:7055/api/c4w-image?FromDate=2019-08-24T14%3A15%3A22Z&ToDate=2019-08-24T14%3A15%3A22Z' \
  --header 'Accept: application/json'
```

`GET /api/c4w-image`

*Get C4W Image List*

Get a filtered, paged and sorted C4W Image List

<h3 id="c4wx1apifeaturesc4wimagegetgetlist-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|FromDate|query|string(date-time)|true|none|
|ToDate|query|string(date-time)|true|none|
|PageIndex|query|integer(int32)|false|none|
|PageSize|query|integer(int32)|false|none|
|OrderBy|query|string|false|none|

> Example responses

> 200 Response

```json
[
  {
    "C4WImageId": 0,
    "WoundImageName": "string",
    "WoundImageData": "string",
    "WoundBedImageName": "string",
    "WoundBedImageData": "string",
    "TissueImageName": "string",
    "TissueImageData": "string",
    "DepthImageName": "string",
    "DepthImageData": "string",
    "IsDeleted": true,
    "CreatedDate": "2019-08-24T14:15:22Z",
    "CreatedBy_FK": 0,
    "ModifiedDate": "2019-08-24T14:15:22Z"
  }
]
```

<h3 id="c4wx1apifeaturesc4wimagegetgetlist-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|C4W Image List retrieved successfully|Inline|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<h3 id="c4wx1apifeaturesc4wimagegetgetlist-responseschema">Response Schema</h3>

Status Code **200**

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[[C4WX1APIFeaturesC4WImageDtosC4WImageDto](#schemac4wx1apifeaturesc4wimagedtosc4wimagedto)]|false|none|none|
|» C4WImageId|integer(int32)|false|none|none|
|» WoundImageName|string¦null|false|none|none|
|» WoundImageData|string¦null|false|none|none|
|» WoundBedImageName|string¦null|false|none|none|
|» WoundBedImageData|string¦null|false|none|none|
|» TissueImageName|string¦null|false|none|none|
|» TissueImageData|string¦null|false|none|none|
|» DepthImageName|string¦null|false|none|none|
|» DepthImageData|string¦null|false|none|none|
|» IsDeleted|boolean|false|none|none|
|» CreatedDate|string(date-time)|false|none|none|
|» CreatedBy_FK|integer(int32)|false|none|none|
|» ModifiedDate|string(date-time)¦null|false|none|none|

<aside class="success">
This operation does not require authentication
</aside>

## C4WX1APIFeaturesC4WImageCreateCreate

<a id="opIdC4WX1APIFeaturesC4WImageCreateCreate"></a>

> Code samples

```shell
curl --request POST \
  --url https://localhost:7055/api/c4w-image \
  --header 'Accept: application/problem+json' \
  --header 'Content-Type: application/json' \
  --data '{"WoundImageName":"wound image name","WoundImageData":"wound image data","WoundBedImageName":"wound bed image name","WoundBedImageData":"wound bed image data","TissueImageName":"tissue image name","TissueImageData":"tissue image data","DepthImageName":"depth image name","DepthImageData":"depth image data","UserId":1}'
```

`POST /api/c4w-image`

*Create C4W Image*

Create a new C4W Image

> Body parameter

```json
{
  "WoundImageName": "wound image name",
  "WoundImageData": "wound image data",
  "WoundBedImageName": "wound bed image name",
  "WoundBedImageData": "wound bed image data",
  "TissueImageName": "tissue image name",
  "TissueImageData": "tissue image data",
  "DepthImageName": "depth image name",
  "DepthImageData": "depth image data",
  "UserId": 1
}
```

<h3 id="c4wx1apifeaturesc4wimagecreatecreate-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[C4WX1APIFeaturesC4WImageDtosCreateC4WImageDto](#schemac4wx1apifeaturesc4wimagedtoscreatec4wimagedto)|true|none|

> Example responses

> 500 Response

```json
{
  "Status": "Internal Server Error!",
  "Code": 500,
  "Reason": "Something unexpected has happened",
  "Note": "See application log for stack trace."
}
```

<h3 id="c4wx1apifeaturesc4wimagecreatecreate-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|204|[No Content](https://tools.ietf.org/html/rfc7231#section-6.3.5)|C4W Image created successfully|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

<h1 id="c4wx1-api-c4w-device-token">C4w-Device-Token</h1>

## C4WX1APIFeaturesC4WDeviceTokenUpdateUpdate

<a id="opIdC4WX1APIFeaturesC4WDeviceTokenUpdateUpdate"></a>

> Code samples

```shell
curl --request PUT \
  --url https://localhost:7055/api/c4w-device-token/0 \
  --header 'Accept: application/problem+json' \
  --header 'Content-Type: application/json' \
  --data '{"OldDeviceToken":"Old token","NewDeviceToken":"New token","ClientEnvironment":"test env","Device":"IPhone","UserId":1}'
```

`PUT /api/c4w-device-token/{c4WDeviceTokenId}`

*Update C4W Device Token*

Update an existing C4W Device Token

> Body parameter

```json
{
  "OldDeviceToken": "Old token",
  "NewDeviceToken": "New token",
  "ClientEnvironment": "test env",
  "Device": "IPhone",
  "UserId": 1
}
```

<h3 id="c4wx1apifeaturesc4wdevicetokenupdateupdate-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|c4WDeviceTokenId|path|integer(int32)|true|none|
|body|body|[C4WX1APIFeaturesC4WDeviceTokenDtosUpdateC4WDeviceTokenDto](#schemac4wx1apifeaturesc4wdevicetokendtosupdatec4wdevicetokendto)|true|none|

> Example responses

> 500 Response

```json
{
  "Status": "Internal Server Error!",
  "Code": 500,
  "Reason": "Something unexpected has happened",
  "Note": "See application log for stack trace."
}
```

<h3 id="c4wx1apifeaturesc4wdevicetokenupdateupdate-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|204|[No Content](https://tools.ietf.org/html/rfc7231#section-6.3.5)|C4W Device Token updated successfully|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## C4WX1APIFeaturesC4WDeviceTokenGetGetByOldDeviceToken

<a id="opIdC4WX1APIFeaturesC4WDeviceTokenGetGetByOldDeviceToken"></a>

> Code samples

```shell
curl --request GET \
  --url 'https://localhost:7055/api/c4w-device-token/old-device-token?OldDeviceToken=string' \
  --header 'Accept: application/json'
```

`GET /api/c4w-device-token/old-device-token`

*Get C4W Device Token by Old Device Token*

Get a C4W Device Token by Old Device Token

<h3 id="c4wx1apifeaturesc4wdevicetokengetgetbyolddevicetoken-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|OldDeviceToken|query|string|true|none|

> Example responses

> 200 Response

```json
{
  "C4WDeviceTokenId": 0,
  "OldDeviceToken": "string",
  "NewDeviceToken": "string",
  "ClientEnvironment": "string",
  "Device": "string",
  "IsDeleted": true,
  "CreatedDate": "2019-08-24T14:15:22Z",
  "CreatedBy_FK": 0,
  "ModifiedDate": "2019-08-24T14:15:22Z",
  "ModifiedBy_FK": 0
}
```

<h3 id="c4wx1apifeaturesc4wdevicetokengetgetbyolddevicetoken-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|C4W Device Token retrieved successfully|[C4WX1APIFeaturesC4WDeviceTokenDtosC4WDeviceTokenDto](#schemac4wx1apifeaturesc4wdevicetokendtosc4wdevicetokendto)|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|C4W Device Token not found|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## C4WX1APIFeaturesC4WDeviceTokenCreateCreate

<a id="opIdC4WX1APIFeaturesC4WDeviceTokenCreateCreate"></a>

> Code samples

```shell
curl --request POST \
  --url https://localhost:7055/api/c4w-device-token \
  --header 'Accept: application/problem+json' \
  --header 'Content-Type: application/json' \
  --data '{"OldDeviceToken":"Old Token","NewDeviceToken":"New Token","ClientEnvironment":"test env","Device":"Iphone","UserId":1}'
```

`POST /api/c4w-device-token`

*Create C4W Device Token*

Create a new C4W Device Token

> Body parameter

```json
{
  "OldDeviceToken": "Old Token",
  "NewDeviceToken": "New Token",
  "ClientEnvironment": "test env",
  "Device": "Iphone",
  "UserId": 1
}
```

<h3 id="c4wx1apifeaturesc4wdevicetokencreatecreate-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[C4WX1APIFeaturesC4WDeviceTokenDtosCreateC4WDeviceTokenDto](#schemac4wx1apifeaturesc4wdevicetokendtoscreatec4wdevicetokendto)|true|none|

> Example responses

> 500 Response

```json
{
  "Status": "Internal Server Error!",
  "Code": 500,
  "Reason": "Something unexpected has happened",
  "Note": "See application log for stack trace."
}
```

<h3 id="c4wx1apifeaturesc4wdevicetokencreatecreate-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|204|[No Content](https://tools.ietf.org/html/rfc7231#section-6.3.5)|No Content|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

<h1 id="c4wx1-api-branch">Branch</h1>

## C4WX1APIFeaturesBranchUpdateUpdate

<a id="opIdC4WX1APIFeaturesBranchUpdateUpdate"></a>

> Code samples

```shell
curl --request PUT \
  --url https://localhost:7055/api/branch/0 \
  --header 'Accept: application/problem+json' \
  --header 'Content-Type: application/json' \
  --data '{"BranchName":"BranchName","Address1":"Address1","Address2":"Address2","Address3":"Address3","Contact":"Contact","Email":"test@test.com","Status":"Active","CurrencyID_FK":1,"UserId":1,"UserDataList":[{"UserId":1,"FirstName":null,"LastName":null}]}'
```

`PUT /api/branch/{branchID}`

*Update Branch*

Update an existing Branch by its ID

> Body parameter

```json
{
  "BranchName": "BranchName",
  "Address1": "Address1",
  "Address2": "Address2",
  "Address3": "Address3",
  "Contact": "Contact",
  "Email": "test@test.com",
  "Status": "Active",
  "CurrencyID_FK": 1,
  "UserId": 1,
  "UserDataList": [
    {
      "UserId": 1,
      "FirstName": null,
      "LastName": null
    }
  ]
}
```

<h3 id="c4wx1apifeaturesbranchupdateupdate-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|branchID|path|integer(int32)|true|none|
|body|body|[C4WX1APIFeaturesBranchDtosUpdateBranchDto](#schemac4wx1apifeaturesbranchdtosupdatebranchdto)|true|none|

> Example responses

> 400 Response

```json
{
  "StatusCode": 400,
  "Message": "One or more errors occurred!",
  "Errors": {
    "property1": [
      "string"
    ],
    "property2": [
      "string"
    ]
  }
}
```

<h3 id="c4wx1apifeaturesbranchupdateupdate-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|204|[No Content](https://tools.ietf.org/html/rfc7231#section-6.3.5)|Branch updated successfully|None|
|400|[Bad Request](https://tools.ietf.org/html/rfc7231#section-6.5.1)|Branch data invalid|[FastEndpointsErrorResponse](#schemafastendpointserrorresponse)|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Branch not found|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## C4WX1APIFeaturesBranchGetGetById

<a id="opIdC4WX1APIFeaturesBranchGetGetById"></a>

> Code samples

```shell
curl --request GET \
  --url https://localhost:7055/api/branch/0 \
  --header 'Accept: application/json'
```

`GET /api/branch/{id}`

*Get Branch*

Get Branch by its ID

<h3 id="c4wx1apifeaturesbranchgetgetbyid-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|integer(int32)|true|none|

> Example responses

> 200 Response

```json
{
  "BranchID": 0,
  "BranchName": "string",
  "Address1": "string",
  "Address2": "string",
  "Address3": "string",
  "Contact": "string",
  "Email": "string",
  "Status": "string",
  "IsSystemUsed": true,
  "CurrencyID_FK": 0,
  "CurrencyName": "string",
  "CanDelete": true,
  "UserDataList": [
    {
      "UserId": 0,
      "FirstName": "string",
      "LastName": "string"
    }
  ]
}
```

<h3 id="c4wx1apifeaturesbranchgetgetbyid-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Branch retrieved successfully|[C4WX1APIFeaturesBranchDtosBranchDto](#schemac4wx1apifeaturesbranchdtosbranchdto)|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Branch not found|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## C4WX1APIFeaturesBranchDeleteDelete

<a id="opIdC4WX1APIFeaturesBranchDeleteDelete"></a>

> Code samples

```shell
curl --request DELETE \
  --url https://localhost:7055/api/branch/0 \
  --header 'Accept: application/problem+json' \
  --header 'Content-Type: */*' \
  --data '{"UserId":1}'
```

`DELETE /api/branch/{id}`

*Delete Branch*

Delete an existing Branch by its ID

> Body parameter

```json
{
  "UserId": 1
}
```

<h3 id="c4wx1apifeaturesbranchdeletedelete-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|integer(int32)|true|none|
|body|body|[C4WX1APIFeaturesBranchDtosDeleteBranchDto](#schemac4wx1apifeaturesbranchdtosdeletebranchdto)|true|none|

> Example responses

> 400 Response

```json
{
  "StatusCode": 400,
  "Message": "One or more errors occurred!",
  "Errors": {
    "property1": [
      "string"
    ],
    "property2": [
      "string"
    ]
  }
}
```

<h3 id="c4wx1apifeaturesbranchdeletedelete-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|204|[No Content](https://tools.ietf.org/html/rfc7231#section-6.3.5)|Branch deleted successfully|None|
|400|[Bad Request](https://tools.ietf.org/html/rfc7231#section-6.5.1)|Branch cannot be deleted|[FastEndpointsErrorResponse](#schemafastendpointserrorresponse)|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Branch not found|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## C4WX1APIFeaturesBranchGetGetCount

<a id="opIdC4WX1APIFeaturesBranchGetGetCount"></a>

> Code samples

```shell
curl --request GET \
  --url https://localhost:7055/api/branch/count \
  --header 'Accept: application/json'
```

`GET /api/branch/count`

*Get Branch Count*

Get number of Branch

> Example responses

> 200 Response

```json
0
```

<h3 id="c4wx1apifeaturesbranchgetgetcount-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Branch Count retrieved successfully|integer|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## C4WX1APIFeaturesBranchGetGetList

<a id="opIdC4WX1APIFeaturesBranchGetGetList"></a>

> Code samples

```shell
curl --request GET \
  --url https://localhost:7055/api/branch \
  --header 'Accept: application/json'
```

`GET /api/branch`

*Get Branch List*

Get a paged and sorted Branch List

<h3 id="c4wx1apifeaturesbranchgetgetlist-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|PageIndex|query|integer(int32)|false|none|
|PageSize|query|integer(int32)|false|none|
|OrderBy|query|string|false|none|

> Example responses

> 200 Response

```json
[
  {
    "BranchID": 0,
    "BranchName": "string",
    "Address1": "string",
    "Address2": "string",
    "Address3": "string",
    "Contact": "string",
    "Email": "string",
    "Status": "string",
    "IsSystemUsed": true,
    "CurrencyID_FK": 0,
    "CurrencyName": "string",
    "CanDelete": true,
    "UserDataList": [
      {
        "UserId": 0,
        "FirstName": "string",
        "LastName": "string"
      }
    ]
  }
]
```

<h3 id="c4wx1apifeaturesbranchgetgetlist-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Branch List retrieved successfully|Inline|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<h3 id="c4wx1apifeaturesbranchgetgetlist-responseschema">Response Schema</h3>

Status Code **200**

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[[C4WX1APIFeaturesBranchDtosBranchDto](#schemac4wx1apifeaturesbranchdtosbranchdto)]|false|none|none|
|» BranchID|integer(int32)|false|none|none|
|» BranchName|string|false|none|none|
|» Address1|string¦null|false|none|none|
|» Address2|string¦null|false|none|none|
|» Address3|string¦null|false|none|none|
|» Contact|string¦null|false|none|none|
|» Email|string¦null|false|none|none|
|» Status|string|false|none|none|
|» IsSystemUsed|boolean|false|none|none|
|» CurrencyID_FK|integer(int32)¦null|false|none|none|
|» CurrencyName|string|false|none|none|
|» CanDelete|boolean|false|none|none|
|» UserDataList|[[C4WX1APIFeaturesBranchDtosBranchUserDto](#schemac4wx1apifeaturesbranchdtosbranchuserdto)]|false|none|none|
|»» UserId|integer(int32)|false|none|none|
|»» FirstName|string|false|none|none|
|»» LastName|string|false|none|none|

<aside class="success">
This operation does not require authentication
</aside>

## C4WX1APIFeaturesBranchCreateCreate

<a id="opIdC4WX1APIFeaturesBranchCreateCreate"></a>

> Code samples

```shell
curl --request POST \
  --url https://localhost:7055/api/branch \
  --header 'Accept: application/problem+json' \
  --header 'Content-Type: application/json' \
  --data '{"BranchID":0,"BranchName":"BranchName","Address1":"Address1","Address2":"Address2","Address3":"Address3","Contact":"Contact","Email":"test@test.com","Status":"Active","CurrencyID_FK":1,"UserId":1,"UserDataList":[{"UserId":1,"FirstName":null,"LastName":null}]}'
```

`POST /api/branch`

*Create Branch*

Create a new Branch

> Body parameter

```json
{
  "BranchID": 0,
  "BranchName": "BranchName",
  "Address1": "Address1",
  "Address2": "Address2",
  "Address3": "Address3",
  "Contact": "Contact",
  "Email": "test@test.com",
  "Status": "Active",
  "CurrencyID_FK": 1,
  "UserId": 1,
  "UserDataList": [
    {
      "UserId": 1,
      "FirstName": null,
      "LastName": null
    }
  ]
}
```

<h3 id="c4wx1apifeaturesbranchcreatecreate-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[C4WX1APIFeaturesBranchDtosCreateBranchDto](#schemac4wx1apifeaturesbranchdtoscreatebranchdto)|true|none|

> Example responses

> 400 Response

```json
{
  "StatusCode": 400,
  "Message": "One or more errors occurred!",
  "Errors": {
    "property1": [
      "string"
    ],
    "property2": [
      "string"
    ]
  }
}
```

<h3 id="c4wx1apifeaturesbranchcreatecreate-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|204|[No Content](https://tools.ietf.org/html/rfc7231#section-6.3.5)|Branch created successfully|None|
|400|[Bad Request](https://tools.ietf.org/html/rfc7231#section-6.5.1)|Branch data invalid|[FastEndpointsErrorResponse](#schemafastendpointserrorresponse)|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## C4WX1APIFeaturesBranchGetGetListForControl

<a id="opIdC4WX1APIFeaturesBranchGetGetListForControl"></a>

> Code samples

```shell
curl --request GET \
  --url https://localhost:7055/api/branch/for-control \
  --header 'Accept: application/json'
```

`GET /api/branch/for-control`

*Get Branch List for Control*

Get sorted Branch List for Control

> Example responses

> 200 Response

```json
[
  {
    "BranchID": 0,
    "BranchName": "string",
    "Address1": "string",
    "Address2": "string",
    "Address3": "string",
    "Contact": "string",
    "Email": "string",
    "Status": "string",
    "IsSystemUsed": true,
    "CurrencyID_FK": 0,
    "CurrencyName": "string",
    "CanDelete": true,
    "UserDataList": [
      {
        "UserId": 0,
        "FirstName": "string",
        "LastName": "string"
      }
    ]
  }
]
```

<h3 id="c4wx1apifeaturesbranchgetgetlistforcontrol-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Branch List retrieved successfully|Inline|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<h3 id="c4wx1apifeaturesbranchgetgetlistforcontrol-responseschema">Response Schema</h3>

Status Code **200**

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[[C4WX1APIFeaturesBranchDtosBranchDto](#schemac4wx1apifeaturesbranchdtosbranchdto)]|false|none|none|
|» BranchID|integer(int32)|false|none|none|
|» BranchName|string|false|none|none|
|» Address1|string¦null|false|none|none|
|» Address2|string¦null|false|none|none|
|» Address3|string¦null|false|none|none|
|» Contact|string¦null|false|none|none|
|» Email|string¦null|false|none|none|
|» Status|string|false|none|none|
|» IsSystemUsed|boolean|false|none|none|
|» CurrencyID_FK|integer(int32)¦null|false|none|none|
|» CurrencyName|string|false|none|none|
|» CanDelete|boolean|false|none|none|
|» UserDataList|[[C4WX1APIFeaturesBranchDtosBranchUserDto](#schemac4wx1apifeaturesbranchdtosbranchuserdto)]|false|none|none|
|»» UserId|integer(int32)|false|none|none|
|»» FirstName|string|false|none|none|
|»» LastName|string|false|none|none|

<aside class="success">
This operation does not require authentication
</aside>

<h1 id="c4wx1-api-billing-proposal">Billing-Proposal</h1>

## C4WX1APIFeaturesBillingProposalUpdateUpdate

<a id="opIdC4WX1APIFeaturesBillingProposalUpdateUpdate"></a>

> Code samples

```shell
curl --request PUT \
  --url https://localhost:7055/api/billing-proposal/0 \
  --header 'Accept: application/problem+json' \
  --header 'Content-Type: application/json' \
  --data '{"PatientID_FK":1,"Title":"Title","SendEmail":true,"EmailPatient":true,"EmailTo":"test-to@gmail.com","EmailCC":"test-cc@gmail.com","EmailBCC":"test-bcc@gmail.com","CurrencyID_FK":1,"Status":"Active","GroupNumber":"1","Version":1,"ProposalType":"ProposalType","UserId":1,"ServiceList":[{"BillingInvoiceServiceID":0,"BillingProposalID_FK":0,"ServiceID_FK":1,"CategoryId":0,"Title":null,"StartDate":"2025-02-27T23:51:34.5331158+08:00","EndDate":"2025-02-27T23:51:34.5365272+08:00","UnitCost":0,"Duration1":"Duration1","Duration2":"Duration2","Visit":1,"Session":0,"Discount":0,"ServiceDescription":"ServiceDescription","CategoryName":null}]}'
```

`PUT /api/billing-proposal/{id}`

*Update Billing Proposal*

Update Billing Proposal by its ID

> Body parameter

```json
{
  "PatientID_FK": 1,
  "Title": "Title",
  "SendEmail": true,
  "EmailPatient": true,
  "EmailTo": "test-to@gmail.com",
  "EmailCC": "test-cc@gmail.com",
  "EmailBCC": "test-bcc@gmail.com",
  "CurrencyID_FK": 1,
  "Status": "Active",
  "GroupNumber": "1",
  "Version": 1,
  "ProposalType": "ProposalType",
  "UserId": 1,
  "ServiceList": [
    {
      "BillingInvoiceServiceID": 0,
      "BillingProposalID_FK": 0,
      "ServiceID_FK": 1,
      "CategoryId": 0,
      "Title": null,
      "StartDate": "2025-02-27T23:51:34.5331158+08:00",
      "EndDate": "2025-02-27T23:51:34.5365272+08:00",
      "UnitCost": 0,
      "Duration1": "Duration1",
      "Duration2": "Duration2",
      "Visit": 1,
      "Session": 0,
      "Discount": 0,
      "ServiceDescription": "ServiceDescription",
      "CategoryName": null
    }
  ]
}
```

<h3 id="c4wx1apifeaturesbillingproposalupdateupdate-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|integer(int32)|true|none|
|body|body|[C4WX1APIFeaturesBillingProposalDtosUpdateBillingProposalDto](#schemac4wx1apifeaturesbillingproposaldtosupdatebillingproposaldto)|true|none|

> Example responses

> 500 Response

```json
{
  "Status": "Internal Server Error!",
  "Code": 500,
  "Reason": "Something unexpected has happened",
  "Note": "See application log for stack trace."
}
```

<h3 id="c4wx1apifeaturesbillingproposalupdateupdate-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|204|[No Content](https://tools.ietf.org/html/rfc7231#section-6.3.5)|Billing Proposal updated successfully|None|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Billing Proposal not found|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## C4WX1APIFeaturesBillingProposalGetGetById

<a id="opIdC4WX1APIFeaturesBillingProposalGetGetById"></a>

> Code samples

```shell
curl --request GET \
  --url https://localhost:7055/api/billing-proposal/0 \
  --header 'Accept: application/json'
```

`GET /api/billing-proposal/{id}`

*Get Billing Proposal*

Get Billing Proposal by its ID

<h3 id="c4wx1apifeaturesbillingproposalgetgetbyid-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|integer(int32)|true|none|

> Example responses

> 200 Response

```json
{
  "BillingProposalID": 0,
  "PatientID_FK": 0,
  "ProposalNumber": "string",
  "Title": "string",
  "SendEmail": true,
  "EmailPatient": true,
  "EmailTo": "string",
  "EmailCC": "string",
  "EmailBCC": "string",
  "CurrencyID_FK": 0,
  "CurrencyCode": "string",
  "TotalCost": 0,
  "Status": "string",
  "GroupNumber": "string",
  "Version": 0,
  "CreatedDate": "2019-08-24T14:15:22Z",
  "CreatedBy_FK": 0,
  "ModifiedDate": "2019-08-24T14:15:22Z",
  "ModifiedBy_FK": 0,
  "IsDeleted": true,
  "ProposalType": "string",
  "PatientData": {
    "PatientID": 0,
    "FirstName": "string",
    "LastName": "string",
    "Photo": "string",
    "MailingAddress1": "string",
    "MailingAddress2": "string",
    "MailingAddress3": "string",
    "MailingPostalCode": "string",
    "Profile": {
      "Email": "string"
    }
  },
  "CreatedByData": {
    "UserId": 0,
    "FirstName": "string",
    "LastName": "string",
    "Photo": "string",
    "Email": "string"
  },
  "ModifiedByData": {
    "UserId": 0,
    "FirstName": "string",
    "LastName": "string",
    "Photo": "string",
    "Email": "string"
  },
  "ServiceList": [
    {
      "BillingInvoiceServiceID": 0,
      "BillingProposalID_FK": 0,
      "ServiceID_FK": 0,
      "CategoryId": 0,
      "Title": "string",
      "StartDate": "2019-08-24T14:15:22Z",
      "EndDate": "2019-08-24T14:15:22Z",
      "UnitCost": 0,
      "Duration1": "string",
      "Duration2": "string",
      "Visit": 0,
      "Session": 0,
      "Discount": 0,
      "ServiceDescription": "string",
      "CategoryName": "string"
    }
  ]
}
```

<h3 id="c4wx1apifeaturesbillingproposalgetgetbyid-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Billing Proposal retrieved succesfully|[C4WX1APIFeaturesBillingProposalDtosBillingProposalDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposaldto)|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Billing Proposal not found|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## C4WX1APIFeaturesBillingProposalDeleteDelete

<a id="opIdC4WX1APIFeaturesBillingProposalDeleteDelete"></a>

> Code samples

```shell
curl --request DELETE \
  --url https://localhost:7055/api/billing-proposal/0 \
  --header 'Accept: application/problem+json' \
  --header 'Content-Type: */*' \
  --data '{"UserId":1}'
```

`DELETE /api/billing-proposal/{id}`

*Delete Billing Proposal*

Delete Billing Proposal by its ID

> Body parameter

```json
{
  "UserId": 1
}
```

<h3 id="c4wx1apifeaturesbillingproposaldeletedelete-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|integer(int32)|true|none|
|body|body|[C4WX1APIFeaturesBillingProposalDtosDeleteBillingProposalDto](#schemac4wx1apifeaturesbillingproposaldtosdeletebillingproposaldto)|true|none|

> Example responses

> 500 Response

```json
{
  "Status": "Internal Server Error!",
  "Code": 500,
  "Reason": "Something unexpected has happened",
  "Note": "See application log for stack trace."
}
```

<h3 id="c4wx1apifeaturesbillingproposaldeletedelete-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|204|[No Content](https://tools.ietf.org/html/rfc7231#section-6.3.5)|No Content|None|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Billing Proposal not found|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## C4WX1APIFeaturesBillingProposalUpdateUpdateStatus

<a id="opIdC4WX1APIFeaturesBillingProposalUpdateUpdateStatus"></a>

> Code samples

```shell
curl --request PUT \
  --url https://localhost:7055/api/billing-proposal/0/status \
  --header 'Accept: application/problem+json' \
  --header 'Content-Type: application/json' \
  --data '{"UserId":1,"Status":"Success"}'
```

`PUT /api/billing-proposal/{id}/status`

*Update Billing Proposal Status*

Update Billing Proposal Status by its ID

> Body parameter

```json
{
  "UserId": 1,
  "Status": "Success"
}
```

<h3 id="c4wx1apifeaturesbillingproposalupdateupdatestatus-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|integer(int32)|true|none|
|body|body|[C4WX1APIFeaturesBillingProposalDtosUpdateBillingProposalStatusDto](#schemac4wx1apifeaturesbillingproposaldtosupdatebillingproposalstatusdto)|true|none|

> Example responses

> 400 Response

```json
{
  "StatusCode": 400,
  "Message": "One or more errors occurred!",
  "Errors": {
    "property1": [
      "string"
    ],
    "property2": [
      "string"
    ]
  }
}
```

<h3 id="c4wx1apifeaturesbillingproposalupdateupdatestatus-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|204|[No Content](https://tools.ietf.org/html/rfc7231#section-6.3.5)|No Content|None|
|400|[Bad Request](https://tools.ietf.org/html/rfc7231#section-6.5.1)|Billing Proposal not found|[FastEndpointsErrorResponse](#schemafastendpointserrorresponse)|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Billing Proposal Status invalid|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## C4WX1APIFeaturesBillingProposalGetGetActiveList

<a id="opIdC4WX1APIFeaturesBillingProposalGetGetActiveList"></a>

> Code samples

```shell
curl --request GET \
  --url https://localhost:7055/api/billing-proposal/active/0 \
  --header 'Accept: application/json'
```

`GET /api/billing-proposal/active/{patientId}`

*Get Active Billing Proposal List*

Get filtered and sorted Active Billing Proposal List by PatientID

<h3 id="c4wx1apifeaturesbillingproposalgetgetactivelist-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|patientId|path|integer(int32)|true|none|

> Example responses

> 200 Response

```json
[
  {
    "BillingProposalID": 0,
    "PatientID_FK": 0,
    "ProposalNumber": "string",
    "Title": "string",
    "SendEmail": true,
    "EmailPatient": true,
    "EmailTo": "string",
    "EmailCC": "string",
    "EmailBCC": "string",
    "CurrencyID_FK": 0,
    "CurrencyCode": "string",
    "TotalCost": 0,
    "Status": "string",
    "GroupNumber": "string",
    "Version": 0,
    "CreatedDate": "2019-08-24T14:15:22Z",
    "CreatedBy_FK": 0,
    "ModifiedDate": "2019-08-24T14:15:22Z",
    "ModifiedBy_FK": 0,
    "IsDeleted": true,
    "ProposalType": "string",
    "PatientData": {
      "PatientID": 0,
      "FirstName": "string",
      "LastName": "string",
      "Photo": "string",
      "MailingAddress1": "string",
      "MailingAddress2": "string",
      "MailingAddress3": "string",
      "MailingPostalCode": "string",
      "Profile": {
        "Email": "string"
      }
    },
    "CreatedByData": {
      "UserId": 0,
      "FirstName": "string",
      "LastName": "string",
      "Photo": "string",
      "Email": "string"
    },
    "ModifiedByData": {
      "UserId": 0,
      "FirstName": "string",
      "LastName": "string",
      "Photo": "string",
      "Email": "string"
    },
    "ServiceList": [
      {
        "BillingInvoiceServiceID": 0,
        "BillingProposalID_FK": 0,
        "ServiceID_FK": 0,
        "CategoryId": 0,
        "Title": "string",
        "StartDate": "2019-08-24T14:15:22Z",
        "EndDate": "2019-08-24T14:15:22Z",
        "UnitCost": 0,
        "Duration1": "string",
        "Duration2": "string",
        "Visit": 0,
        "Session": 0,
        "Discount": 0,
        "ServiceDescription": "string",
        "CategoryName": "string"
      }
    ]
  }
]
```

<h3 id="c4wx1apifeaturesbillingproposalgetgetactivelist-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Billing Proposal List retrieved successfully|Inline|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<h3 id="c4wx1apifeaturesbillingproposalgetgetactivelist-responseschema">Response Schema</h3>

Status Code **200**

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[[C4WX1APIFeaturesBillingProposalDtosBillingProposalDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposaldto)]|false|none|none|
|» BillingProposalID|integer(int32)|false|none|none|
|» PatientID_FK|integer(int32)|false|none|none|
|» ProposalNumber|string|false|none|none|
|» Title|string|false|none|none|
|» SendEmail|boolean¦null|false|none|none|
|» EmailPatient|boolean¦null|false|none|none|
|» EmailTo|string¦null|false|none|none|
|» EmailCC|string¦null|false|none|none|
|» EmailBCC|string¦null|false|none|none|
|» CurrencyID_FK|integer(int32)|false|none|none|
|» CurrencyCode|string|false|none|none|
|» TotalCost|number(decimal)|false|none|none|
|» Status|string|false|none|none|
|» GroupNumber|string|false|none|none|
|» Version|integer|false|none|none|
|» CreatedDate|string(date-time)|false|none|none|
|» CreatedBy_FK|integer(int32)|false|none|none|
|» ModifiedDate|string(date-time)¦null|false|none|none|
|» ModifiedBy_FK|integer(int32)¦null|false|none|none|
|» IsDeleted|boolean|false|none|none|
|» ProposalType|string|false|none|none|
|» PatientData|[C4WX1APIFeaturesBillingProposalDtosBillingProposalPatientDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposalpatientdto)|false|none|none|
|»» PatientID|integer(int32)|false|none|none|
|»» FirstName|string|false|none|none|
|»» LastName|string|false|none|none|
|»» Photo|string¦null|false|none|none|
|»» MailingAddress1|string¦null|false|none|none|
|»» MailingAddress2|string¦null|false|none|none|
|»» MailingAddress3|string¦null|false|none|none|
|»» MailingPostalCode|string¦null|false|none|none|
|»» Profile|[C4WX1APIFeaturesBillingProposalDtosBillingProposalPatientProfileDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposalpatientprofiledto)¦null|false|none|none|
|»»» Email|string¦null|false|none|none|
|» CreatedByData|[C4WX1APIFeaturesBillingProposalDtosBillingProposalUserDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposaluserdto)|false|none|none|
|»» UserId|integer(int32)|false|none|none|
|»» FirstName|string|false|none|none|
|»» LastName|string|false|none|none|
|»» Photo|string¦null|false|none|none|
|»» Email|string|false|none|none|
|» ModifiedByData|[C4WX1APIFeaturesBillingProposalDtosBillingProposalUserDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposaluserdto)¦null|false|none|none|
|»» UserId|integer(int32)|false|none|none|
|»» FirstName|string|false|none|none|
|»» LastName|string|false|none|none|
|»» Photo|string¦null|false|none|none|
|»» Email|string|false|none|none|
|» ServiceList|[[C4WX1APIFeaturesBillingProposalDtosBillingProposalServiceDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposalservicedto)]|false|none|none|
|»» BillingInvoiceServiceID|integer(int32)|false|none|none|
|»» BillingProposalID_FK|integer(int32)|false|none|none|
|»» ServiceID_FK|integer(int32)|false|none|none|
|»» CategoryId|integer(int32)|false|none|none|
|»» Title|string|false|none|none|
|»» StartDate|string(date-time)|false|none|none|
|»» EndDate|string(date-time)|false|none|none|
|»» UnitCost|number(decimal)|false|none|none|
|»» Duration1|string¦null|false|none|none|
|»» Duration2|string¦null|false|none|none|
|»» Visit|integer(int32)|false|none|none|
|»» Session|integer(int32)|false|none|none|
|»» Discount|number(decimal)|false|none|none|
|»» ServiceDescription|string¦null|false|none|none|
|»» CategoryName|string|false|none|none|

<aside class="success">
This operation does not require authentication
</aside>

## C4WX1APIFeaturesBillingProposalGetGetAllList

<a id="opIdC4WX1APIFeaturesBillingProposalGetGetAllList"></a>

> Code samples

```shell
curl --request GET \
  --url https://localhost:7055/api/billing-proposal/all \
  --header 'Accept: application/json'
```

`GET /api/billing-proposal/all`

*Get All Billing Proposal List*

Get all filtered and sorted Billing Proposal List

<h3 id="c4wx1apifeaturesbillingproposalgetgetalllist-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|Keyword|query|string|false|none|
|Status|query|string|false|none|
|OrderBy|query|string|false|none|

> Example responses

> 200 Response

```json
[
  {
    "BillingProposalID": 0,
    "PatientID_FK": 0,
    "ProposalNumber": "string",
    "Title": "string",
    "SendEmail": true,
    "EmailPatient": true,
    "EmailTo": "string",
    "EmailCC": "string",
    "EmailBCC": "string",
    "CurrencyID_FK": 0,
    "CurrencyCode": "string",
    "TotalCost": 0,
    "Status": "string",
    "GroupNumber": "string",
    "Version": 0,
    "CreatedDate": "2019-08-24T14:15:22Z",
    "CreatedBy_FK": 0,
    "ModifiedDate": "2019-08-24T14:15:22Z",
    "ModifiedBy_FK": 0,
    "IsDeleted": true,
    "ProposalType": "string",
    "PatientData": {
      "PatientID": 0,
      "FirstName": "string",
      "LastName": "string",
      "Photo": "string",
      "MailingAddress1": "string",
      "MailingAddress2": "string",
      "MailingAddress3": "string",
      "MailingPostalCode": "string",
      "Profile": {
        "Email": "string"
      }
    },
    "CreatedByData": {
      "UserId": 0,
      "FirstName": "string",
      "LastName": "string",
      "Photo": "string",
      "Email": "string"
    },
    "ModifiedByData": {
      "UserId": 0,
      "FirstName": "string",
      "LastName": "string",
      "Photo": "string",
      "Email": "string"
    },
    "ServiceList": [
      {
        "BillingInvoiceServiceID": 0,
        "BillingProposalID_FK": 0,
        "ServiceID_FK": 0,
        "CategoryId": 0,
        "Title": "string",
        "StartDate": "2019-08-24T14:15:22Z",
        "EndDate": "2019-08-24T14:15:22Z",
        "UnitCost": 0,
        "Duration1": "string",
        "Duration2": "string",
        "Visit": 0,
        "Session": 0,
        "Discount": 0,
        "ServiceDescription": "string",
        "CategoryName": "string"
      }
    ]
  }
]
```

<h3 id="c4wx1apifeaturesbillingproposalgetgetalllist-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Billing Proposal List retrieved successfully|Inline|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<h3 id="c4wx1apifeaturesbillingproposalgetgetalllist-responseschema">Response Schema</h3>

Status Code **200**

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[[C4WX1APIFeaturesBillingProposalDtosBillingProposalDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposaldto)]|false|none|none|
|» BillingProposalID|integer(int32)|false|none|none|
|» PatientID_FK|integer(int32)|false|none|none|
|» ProposalNumber|string|false|none|none|
|» Title|string|false|none|none|
|» SendEmail|boolean¦null|false|none|none|
|» EmailPatient|boolean¦null|false|none|none|
|» EmailTo|string¦null|false|none|none|
|» EmailCC|string¦null|false|none|none|
|» EmailBCC|string¦null|false|none|none|
|» CurrencyID_FK|integer(int32)|false|none|none|
|» CurrencyCode|string|false|none|none|
|» TotalCost|number(decimal)|false|none|none|
|» Status|string|false|none|none|
|» GroupNumber|string|false|none|none|
|» Version|integer|false|none|none|
|» CreatedDate|string(date-time)|false|none|none|
|» CreatedBy_FK|integer(int32)|false|none|none|
|» ModifiedDate|string(date-time)¦null|false|none|none|
|» ModifiedBy_FK|integer(int32)¦null|false|none|none|
|» IsDeleted|boolean|false|none|none|
|» ProposalType|string|false|none|none|
|» PatientData|[C4WX1APIFeaturesBillingProposalDtosBillingProposalPatientDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposalpatientdto)|false|none|none|
|»» PatientID|integer(int32)|false|none|none|
|»» FirstName|string|false|none|none|
|»» LastName|string|false|none|none|
|»» Photo|string¦null|false|none|none|
|»» MailingAddress1|string¦null|false|none|none|
|»» MailingAddress2|string¦null|false|none|none|
|»» MailingAddress3|string¦null|false|none|none|
|»» MailingPostalCode|string¦null|false|none|none|
|»» Profile|[C4WX1APIFeaturesBillingProposalDtosBillingProposalPatientProfileDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposalpatientprofiledto)¦null|false|none|none|
|»»» Email|string¦null|false|none|none|
|» CreatedByData|[C4WX1APIFeaturesBillingProposalDtosBillingProposalUserDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposaluserdto)|false|none|none|
|»» UserId|integer(int32)|false|none|none|
|»» FirstName|string|false|none|none|
|»» LastName|string|false|none|none|
|»» Photo|string¦null|false|none|none|
|»» Email|string|false|none|none|
|» ModifiedByData|[C4WX1APIFeaturesBillingProposalDtosBillingProposalUserDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposaluserdto)¦null|false|none|none|
|»» UserId|integer(int32)|false|none|none|
|»» FirstName|string|false|none|none|
|»» LastName|string|false|none|none|
|»» Photo|string¦null|false|none|none|
|»» Email|string|false|none|none|
|» ServiceList|[[C4WX1APIFeaturesBillingProposalDtosBillingProposalServiceDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposalservicedto)]|false|none|none|
|»» BillingInvoiceServiceID|integer(int32)|false|none|none|
|»» BillingProposalID_FK|integer(int32)|false|none|none|
|»» ServiceID_FK|integer(int32)|false|none|none|
|»» CategoryId|integer(int32)|false|none|none|
|»» Title|string|false|none|none|
|»» StartDate|string(date-time)|false|none|none|
|»» EndDate|string(date-time)|false|none|none|
|»» UnitCost|number(decimal)|false|none|none|
|»» Duration1|string¦null|false|none|none|
|»» Duration2|string¦null|false|none|none|
|»» Visit|integer(int32)|false|none|none|
|»» Session|integer(int32)|false|none|none|
|»» Discount|number(decimal)|false|none|none|
|»» ServiceDescription|string¦null|false|none|none|
|»» CategoryName|string|false|none|none|

<aside class="success">
This operation does not require authentication
</aside>

## C4WX1APIFeaturesBillingProposalGetGetCount

<a id="opIdC4WX1APIFeaturesBillingProposalGetGetCount"></a>

> Code samples

```shell
curl --request GET \
  --url https://localhost:7055/api/billing-proposal/count \
  --header 'Accept: application/json'
```

`GET /api/billing-proposal/count`

*Get Billing Proposal Count*

Get filtered Billing Proposal Count

<h3 id="c4wx1apifeaturesbillingproposalgetgetcount-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|Keyword|query|string|false|none|
|Status|query|string|false|none|

> Example responses

> 200 Response

```json
0
```

<h3 id="c4wx1apifeaturesbillingproposalgetgetcount-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Billing Proposal Count retrieved successfully|integer|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## C4WX1APIFeaturesBillingProposalGetGetHistoryList

<a id="opIdC4WX1APIFeaturesBillingProposalGetGetHistoryList"></a>

> Code samples

```shell
curl --request GET \
  --url https://localhost:7055/api/billing-proposal/history \
  --header 'Accept: application/json'
```

`GET /api/billing-proposal/history`

*Get History Billing Proposal List*

Get filtered and sorted History Billing Proposal List

<h3 id="c4wx1apifeaturesbillingproposalgetgethistorylist-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|GroupNumber|query|string|false|none|
|OrderBy|query|string|false|none|

> Example responses

> 200 Response

```json
[
  {
    "BillingProposalID": 0,
    "PatientID_FK": 0,
    "ProposalNumber": "string",
    "Title": "string",
    "SendEmail": true,
    "EmailPatient": true,
    "EmailTo": "string",
    "EmailCC": "string",
    "EmailBCC": "string",
    "CurrencyID_FK": 0,
    "CurrencyCode": "string",
    "TotalCost": 0,
    "Status": "string",
    "GroupNumber": "string",
    "Version": 0,
    "CreatedDate": "2019-08-24T14:15:22Z",
    "CreatedBy_FK": 0,
    "ModifiedDate": "2019-08-24T14:15:22Z",
    "ModifiedBy_FK": 0,
    "IsDeleted": true,
    "ProposalType": "string",
    "PatientData": {
      "PatientID": 0,
      "FirstName": "string",
      "LastName": "string",
      "Photo": "string",
      "MailingAddress1": "string",
      "MailingAddress2": "string",
      "MailingAddress3": "string",
      "MailingPostalCode": "string",
      "Profile": {
        "Email": "string"
      }
    },
    "CreatedByData": {
      "UserId": 0,
      "FirstName": "string",
      "LastName": "string",
      "Photo": "string",
      "Email": "string"
    },
    "ModifiedByData": {
      "UserId": 0,
      "FirstName": "string",
      "LastName": "string",
      "Photo": "string",
      "Email": "string"
    },
    "ServiceList": [
      {
        "BillingInvoiceServiceID": 0,
        "BillingProposalID_FK": 0,
        "ServiceID_FK": 0,
        "CategoryId": 0,
        "Title": "string",
        "StartDate": "2019-08-24T14:15:22Z",
        "EndDate": "2019-08-24T14:15:22Z",
        "UnitCost": 0,
        "Duration1": "string",
        "Duration2": "string",
        "Visit": 0,
        "Session": 0,
        "Discount": 0,
        "ServiceDescription": "string",
        "CategoryName": "string"
      }
    ]
  }
]
```

<h3 id="c4wx1apifeaturesbillingproposalgetgethistorylist-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Billing Proposal List retrieved successfully|Inline|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<h3 id="c4wx1apifeaturesbillingproposalgetgethistorylist-responseschema">Response Schema</h3>

Status Code **200**

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[[C4WX1APIFeaturesBillingProposalDtosBillingProposalDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposaldto)]|false|none|none|
|» BillingProposalID|integer(int32)|false|none|none|
|» PatientID_FK|integer(int32)|false|none|none|
|» ProposalNumber|string|false|none|none|
|» Title|string|false|none|none|
|» SendEmail|boolean¦null|false|none|none|
|» EmailPatient|boolean¦null|false|none|none|
|» EmailTo|string¦null|false|none|none|
|» EmailCC|string¦null|false|none|none|
|» EmailBCC|string¦null|false|none|none|
|» CurrencyID_FK|integer(int32)|false|none|none|
|» CurrencyCode|string|false|none|none|
|» TotalCost|number(decimal)|false|none|none|
|» Status|string|false|none|none|
|» GroupNumber|string|false|none|none|
|» Version|integer|false|none|none|
|» CreatedDate|string(date-time)|false|none|none|
|» CreatedBy_FK|integer(int32)|false|none|none|
|» ModifiedDate|string(date-time)¦null|false|none|none|
|» ModifiedBy_FK|integer(int32)¦null|false|none|none|
|» IsDeleted|boolean|false|none|none|
|» ProposalType|string|false|none|none|
|» PatientData|[C4WX1APIFeaturesBillingProposalDtosBillingProposalPatientDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposalpatientdto)|false|none|none|
|»» PatientID|integer(int32)|false|none|none|
|»» FirstName|string|false|none|none|
|»» LastName|string|false|none|none|
|»» Photo|string¦null|false|none|none|
|»» MailingAddress1|string¦null|false|none|none|
|»» MailingAddress2|string¦null|false|none|none|
|»» MailingAddress3|string¦null|false|none|none|
|»» MailingPostalCode|string¦null|false|none|none|
|»» Profile|[C4WX1APIFeaturesBillingProposalDtosBillingProposalPatientProfileDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposalpatientprofiledto)¦null|false|none|none|
|»»» Email|string¦null|false|none|none|
|» CreatedByData|[C4WX1APIFeaturesBillingProposalDtosBillingProposalUserDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposaluserdto)|false|none|none|
|»» UserId|integer(int32)|false|none|none|
|»» FirstName|string|false|none|none|
|»» LastName|string|false|none|none|
|»» Photo|string¦null|false|none|none|
|»» Email|string|false|none|none|
|» ModifiedByData|[C4WX1APIFeaturesBillingProposalDtosBillingProposalUserDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposaluserdto)¦null|false|none|none|
|»» UserId|integer(int32)|false|none|none|
|»» FirstName|string|false|none|none|
|»» LastName|string|false|none|none|
|»» Photo|string¦null|false|none|none|
|»» Email|string|false|none|none|
|» ServiceList|[[C4WX1APIFeaturesBillingProposalDtosBillingProposalServiceDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposalservicedto)]|false|none|none|
|»» BillingInvoiceServiceID|integer(int32)|false|none|none|
|»» BillingProposalID_FK|integer(int32)|false|none|none|
|»» ServiceID_FK|integer(int32)|false|none|none|
|»» CategoryId|integer(int32)|false|none|none|
|»» Title|string|false|none|none|
|»» StartDate|string(date-time)|false|none|none|
|»» EndDate|string(date-time)|false|none|none|
|»» UnitCost|number(decimal)|false|none|none|
|»» Duration1|string¦null|false|none|none|
|»» Duration2|string¦null|false|none|none|
|»» Visit|integer(int32)|false|none|none|
|»» Session|integer(int32)|false|none|none|
|»» Discount|number(decimal)|false|none|none|
|»» ServiceDescription|string¦null|false|none|none|
|»» CategoryName|string|false|none|none|

<aside class="success">
This operation does not require authentication
</aside>

## C4WX1APIFeaturesBillingProposalGetGetList

<a id="opIdC4WX1APIFeaturesBillingProposalGetGetList"></a>

> Code samples

```shell
curl --request GET \
  --url https://localhost:7055/api/billing-proposal \
  --header 'Accept: application/json'
```

`GET /api/billing-proposal`

*Get Billing Proposal List*

Get a filtered, paged and sorted list of Billing Proposals

<h3 id="c4wx1apifeaturesbillingproposalgetgetlist-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|Keyword|query|string|false|none|
|Status|query|string|false|none|
|PageIndex|query|integer(int32)|false|none|
|PageSize|query|integer(int32)|false|none|
|OrderBy|query|string|false|none|

> Example responses

> 200 Response

```json
[
  {
    "BillingProposalID": 0,
    "PatientID_FK": 0,
    "ProposalNumber": "string",
    "Title": "string",
    "SendEmail": true,
    "EmailPatient": true,
    "EmailTo": "string",
    "EmailCC": "string",
    "EmailBCC": "string",
    "CurrencyID_FK": 0,
    "CurrencyCode": "string",
    "TotalCost": 0,
    "Status": "string",
    "GroupNumber": "string",
    "Version": 0,
    "CreatedDate": "2019-08-24T14:15:22Z",
    "CreatedBy_FK": 0,
    "ModifiedDate": "2019-08-24T14:15:22Z",
    "ModifiedBy_FK": 0,
    "IsDeleted": true,
    "ProposalType": "string",
    "PatientData": {
      "PatientID": 0,
      "FirstName": "string",
      "LastName": "string",
      "Photo": "string",
      "MailingAddress1": "string",
      "MailingAddress2": "string",
      "MailingAddress3": "string",
      "MailingPostalCode": "string",
      "Profile": {
        "Email": "string"
      }
    },
    "CreatedByData": {
      "UserId": 0,
      "FirstName": "string",
      "LastName": "string",
      "Photo": "string",
      "Email": "string"
    },
    "ModifiedByData": {
      "UserId": 0,
      "FirstName": "string",
      "LastName": "string",
      "Photo": "string",
      "Email": "string"
    },
    "ServiceList": [
      {
        "BillingInvoiceServiceID": 0,
        "BillingProposalID_FK": 0,
        "ServiceID_FK": 0,
        "CategoryId": 0,
        "Title": "string",
        "StartDate": "2019-08-24T14:15:22Z",
        "EndDate": "2019-08-24T14:15:22Z",
        "UnitCost": 0,
        "Duration1": "string",
        "Duration2": "string",
        "Visit": 0,
        "Session": 0,
        "Discount": 0,
        "ServiceDescription": "string",
        "CategoryName": "string"
      }
    ]
  }
]
```

<h3 id="c4wx1apifeaturesbillingproposalgetgetlist-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Billing Proposal List retrieved successfully|Inline|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<h3 id="c4wx1apifeaturesbillingproposalgetgetlist-responseschema">Response Schema</h3>

Status Code **200**

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[[C4WX1APIFeaturesBillingProposalDtosBillingProposalDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposaldto)]|false|none|none|
|» BillingProposalID|integer(int32)|false|none|none|
|» PatientID_FK|integer(int32)|false|none|none|
|» ProposalNumber|string|false|none|none|
|» Title|string|false|none|none|
|» SendEmail|boolean¦null|false|none|none|
|» EmailPatient|boolean¦null|false|none|none|
|» EmailTo|string¦null|false|none|none|
|» EmailCC|string¦null|false|none|none|
|» EmailBCC|string¦null|false|none|none|
|» CurrencyID_FK|integer(int32)|false|none|none|
|» CurrencyCode|string|false|none|none|
|» TotalCost|number(decimal)|false|none|none|
|» Status|string|false|none|none|
|» GroupNumber|string|false|none|none|
|» Version|integer|false|none|none|
|» CreatedDate|string(date-time)|false|none|none|
|» CreatedBy_FK|integer(int32)|false|none|none|
|» ModifiedDate|string(date-time)¦null|false|none|none|
|» ModifiedBy_FK|integer(int32)¦null|false|none|none|
|» IsDeleted|boolean|false|none|none|
|» ProposalType|string|false|none|none|
|» PatientData|[C4WX1APIFeaturesBillingProposalDtosBillingProposalPatientDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposalpatientdto)|false|none|none|
|»» PatientID|integer(int32)|false|none|none|
|»» FirstName|string|false|none|none|
|»» LastName|string|false|none|none|
|»» Photo|string¦null|false|none|none|
|»» MailingAddress1|string¦null|false|none|none|
|»» MailingAddress2|string¦null|false|none|none|
|»» MailingAddress3|string¦null|false|none|none|
|»» MailingPostalCode|string¦null|false|none|none|
|»» Profile|[C4WX1APIFeaturesBillingProposalDtosBillingProposalPatientProfileDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposalpatientprofiledto)¦null|false|none|none|
|»»» Email|string¦null|false|none|none|
|» CreatedByData|[C4WX1APIFeaturesBillingProposalDtosBillingProposalUserDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposaluserdto)|false|none|none|
|»» UserId|integer(int32)|false|none|none|
|»» FirstName|string|false|none|none|
|»» LastName|string|false|none|none|
|»» Photo|string¦null|false|none|none|
|»» Email|string|false|none|none|
|» ModifiedByData|[C4WX1APIFeaturesBillingProposalDtosBillingProposalUserDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposaluserdto)¦null|false|none|none|
|»» UserId|integer(int32)|false|none|none|
|»» FirstName|string|false|none|none|
|»» LastName|string|false|none|none|
|»» Photo|string¦null|false|none|none|
|»» Email|string|false|none|none|
|» ServiceList|[[C4WX1APIFeaturesBillingProposalDtosBillingProposalServiceDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposalservicedto)]|false|none|none|
|»» BillingInvoiceServiceID|integer(int32)|false|none|none|
|»» BillingProposalID_FK|integer(int32)|false|none|none|
|»» ServiceID_FK|integer(int32)|false|none|none|
|»» CategoryId|integer(int32)|false|none|none|
|»» Title|string|false|none|none|
|»» StartDate|string(date-time)|false|none|none|
|»» EndDate|string(date-time)|false|none|none|
|»» UnitCost|number(decimal)|false|none|none|
|»» Duration1|string¦null|false|none|none|
|»» Duration2|string¦null|false|none|none|
|»» Visit|integer(int32)|false|none|none|
|»» Session|integer(int32)|false|none|none|
|»» Discount|number(decimal)|false|none|none|
|»» ServiceDescription|string¦null|false|none|none|
|»» CategoryName|string|false|none|none|

<aside class="success">
This operation does not require authentication
</aside>

## C4WX1APIFeaturesBillingProposalCreateCreate

<a id="opIdC4WX1APIFeaturesBillingProposalCreateCreate"></a>

> Code samples

```shell
curl --request POST \
  --url https://localhost:7055/api/billing-proposal \
  --header 'Accept: application/problem+json' \
  --header 'Content-Type: application/json' \
  --data '{"PatientID_FK":1,"Title":"Title","SendEmail":true,"EmailPatient":true,"EmailTo":"test-to@gmail.com","EmailCC":"test-cc@gmail.com","EmailBCC":"test-bcc@gmail.com","CurrencyID_FK":1,"Status":"Active","GroupNumber":"1","Version":1,"ProposalType":"ProposalType","UserId":1,"ServiceList":[{"BillingInvoiceServiceID":0,"BillingProposalID_FK":0,"ServiceID_FK":1,"CategoryId":0,"Title":null,"StartDate":"2025-02-27T23:51:34.5585733+08:00","EndDate":"2025-02-27T23:51:34.558576+08:00","UnitCost":0,"Duration1":"Duration1","Duration2":"Duration2","Visit":1,"Session":0,"Discount":0,"ServiceDescription":"ServiceDescription","CategoryName":null}]}'
```

`POST /api/billing-proposal`

*Create Billing Proposal*

Create new Billing Proposal

> Body parameter

```json
{
  "PatientID_FK": 1,
  "Title": "Title",
  "SendEmail": true,
  "EmailPatient": true,
  "EmailTo": "test-to@gmail.com",
  "EmailCC": "test-cc@gmail.com",
  "EmailBCC": "test-bcc@gmail.com",
  "CurrencyID_FK": 1,
  "Status": "Active",
  "GroupNumber": "1",
  "Version": 1,
  "ProposalType": "ProposalType",
  "UserId": 1,
  "ServiceList": [
    {
      "BillingInvoiceServiceID": 0,
      "BillingProposalID_FK": 0,
      "ServiceID_FK": 1,
      "CategoryId": 0,
      "Title": null,
      "StartDate": "2025-02-27T23:51:34.5585733+08:00",
      "EndDate": "2025-02-27T23:51:34.558576+08:00",
      "UnitCost": 0,
      "Duration1": "Duration1",
      "Duration2": "Duration2",
      "Visit": 1,
      "Session": 0,
      "Discount": 0,
      "ServiceDescription": "ServiceDescription",
      "CategoryName": null
    }
  ]
}
```

<h3 id="c4wx1apifeaturesbillingproposalcreatecreate-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[C4WX1APIFeaturesBillingProposalDtosCreateBillingProposalDto](#schemac4wx1apifeaturesbillingproposaldtoscreatebillingproposaldto)|true|none|

> Example responses

> 500 Response

```json
{
  "Status": "Internal Server Error!",
  "Code": 500,
  "Reason": "Something unexpected has happened",
  "Note": "See application log for stack trace."
}
```

<h3 id="c4wx1apifeaturesbillingproposalcreatecreate-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|204|[No Content](https://tools.ietf.org/html/rfc7231#section-6.3.5)|No Content|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## C4WX1APIFeaturesBillingProposalGetGetSessionBalance

<a id="opIdC4WX1APIFeaturesBillingProposalGetGetSessionBalance"></a>

> Code samples

```shell
curl --request GET \
  --url 'https://localhost:7055/api/billing-proposal/session-balance?ProposalId=0&ServiceId=0&EndDate=2019-08-24T14%3A15%3A22Z' \
  --header 'Accept: application/json'
```

`GET /api/billing-proposal/session-balance`

*Get Billing Proposal Session Balance*

Get Billing Proposal Session Balance by its ProposalId, ServiceId and EndDate

<h3 id="c4wx1apifeaturesbillingproposalgetgetsessionbalance-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|ProposalId|query|integer(int32)|true|none|
|ServiceId|query|integer(int32)|true|none|
|EndDate|query|string(date-time)|true|none|

> Example responses

> 200 Response

```json
"string"
```

<h3 id="c4wx1apifeaturesbillingproposalgetgetsessionbalance-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Billing Proposal Session Balance retrieved successfully|string|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

<h1 id="c4wx1-api-api-access-key">Api-Access-Key</h1>

## C4WX1APIFeaturesAPIAccessKeyGetGet

<a id="opIdC4WX1APIFeaturesAPIAccessKeyGetGet"></a>

> Code samples

```shell
curl --request GET \
  --url https://localhost:7055/api/api-access-key/0 \
  --header 'Accept: application/json'
```

`GET /api/api-access-key/{id}`

*Get APIAccessKey*

Get APIAccessKey by its ID or Access Key

<h3 id="c4wx1apifeaturesapiaccesskeygetget-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|integer(int32)|true|none|
|AccessKey|query|string|false|none|

> Example responses

> 200 Response

```json
{
  "APIAccessKeyID": 0,
  "TokenCode": "string",
  "AccessKey": "string",
  "ExpiryDate": "2019-08-24T14:15:22Z",
  "CreatedDate": "2019-08-24T14:15:22Z",
  "UpdatedDate": "2019-08-24T14:15:22Z",
  "UserId_FK": 0
}
```

<h3 id="c4wx1apifeaturesapiaccesskeygetget-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|APIAccessKey retrieved successfully|[C4WX1APIFeaturesAPIAccessKeyDtosAPIAccessKeyDto](#schemac4wx1apifeaturesapiaccesskeydtosapiaccesskeydto)|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|APIAccessKey not found|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## C4WX1APIFeaturesAPIAccessKeyCreateCreate

<a id="opIdC4WX1APIFeaturesAPIAccessKeyCreateCreate"></a>

> Code samples

```shell
curl --request POST \
  --url https://localhost:7055/api/api-access-key \
  --header 'Accept: application/json' \
  --header 'Content-Type: application/json' \
  --data '{"Code":"string","UserId":0}'
```

`POST /api/api-access-key`

*Create APIAccessKey*

Create a new APIAccessKey

> Body parameter

```json
{
  "Code": "string",
  "UserId": 0
}
```

<h3 id="c4wx1apifeaturesapiaccesskeycreatecreate-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[C4WX1APIFeaturesAPIAccessKeyDtosCreateAPIAccessKeyDto](#schemac4wx1apifeaturesapiaccesskeydtoscreateapiaccesskeydto)|true|none|

> Example responses

> 200 Response

```json
{
  "APIAccessKeyID": 0,
  "TokenCode": "string",
  "AccessKey": "string",
  "ExpiryDate": "2019-08-24T14:15:22Z",
  "CreatedDate": "2019-08-24T14:15:22Z",
  "UpdatedDate": "2019-08-24T14:15:22Z",
  "UserId_FK": 0
}
```

<h3 id="c4wx1apifeaturesapiaccesskeycreatecreate-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|APIAccessKey created successfully|[C4WX1APIFeaturesAPIAccessKeyDtosAPIAccessKeyDto](#schemac4wx1apifeaturesapiaccesskeydtosapiaccesskeydto)|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|APIAccessKey not found|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

<h1 id="c4wx1-api-activity">Activity</h1>

## C4WX1APIFeaturesActivityUpdateUpdate

<a id="opIdC4WX1APIFeaturesActivityUpdateUpdate"></a>

> Code samples

```shell
curl --request PUT \
  --url https://localhost:7055/api/activity/0 \
  --header 'Accept: application/problem+json' \
  --header 'Content-Type: application/json' \
  --data '{"ProblemListID_FK":1,"DiseaseID_FK":1,"ActivityDetail":"Activity Detail","DiseaseSubInfoID_FK":1,"UserId":1}'
```

`PUT /api/activity/{activityID}`

*Update Activity*

Update an existing Activity

> Body parameter

```json
{
  "ProblemListID_FK": 1,
  "DiseaseID_FK": 1,
  "ActivityDetail": "Activity Detail",
  "DiseaseSubInfoID_FK": 1,
  "UserId": 1
}
```

<h3 id="c4wx1apifeaturesactivityupdateupdate-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|activityID|path|integer(int32)|true|none|
|body|body|[C4WX1APIFeaturesActivityDtosUpdateActivityDto](#schemac4wx1apifeaturesactivitydtosupdateactivitydto)|true|none|

> Example responses

> 500 Response

```json
{
  "Status": "Internal Server Error!",
  "Code": 500,
  "Reason": "Something unexpected has happened",
  "Note": "See application log for stack trace."
}
```

<h3 id="c4wx1apifeaturesactivityupdateupdate-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|204|[No Content](https://tools.ietf.org/html/rfc7231#section-6.3.5)|Activity updated successfully|None|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Activity not found|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## C4WX1APIFeaturesActivityGetGetById

<a id="opIdC4WX1APIFeaturesActivityGetGetById"></a>

> Code samples

```shell
curl --request GET \
  --url https://localhost:7055/api/activity/0 \
  --header 'Accept: application/json'
```

`GET /api/activity/{Id}`

*Get Activity*

Get an Activity by its ID

<h3 id="c4wx1apifeaturesactivitygetgetbyid-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|Id|path|integer(int32)|true|none|

> Example responses

> 200 Response

```json
{
  "ActivityID": 0,
  "ProblemListID_FK": 0,
  "DiseaseID_FK": 0,
  "ActivityDetail": "string",
  "IsDeleted": true,
  "CreatedDate": "2019-08-24T14:15:22Z",
  "CreatedBy_FK": 0,
  "ModifiedDate": "2019-08-24T14:15:22Z",
  "ModifiedBy_FK": 0,
  "DiseaseSubInfoID_FK": 0,
  "CanDelete": true
}
```

<h3 id="c4wx1apifeaturesactivitygetgetbyid-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Activity retrieved successfully|[C4WX1APIFeaturesActivityDtosActivityDto](#schemac4wx1apifeaturesactivitydtosactivitydto)|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Activity not found|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## C4WX1APIFeaturesActivityGetGetCount

<a id="opIdC4WX1APIFeaturesActivityGetGetCount"></a>

> Code samples

```shell
curl --request GET \
  --url https://localhost:7055/api/activity/count \
  --header 'Accept: application/json'
```

`GET /api/activity/count`

*Get Activity Count*

Get the number of activities

> Example responses

> 200 Response

```json
0
```

<h3 id="c4wx1apifeaturesactivitygetgetcount-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Number of activities retrieved successfully|integer|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## C4WX1APIFeaturesActivityGetGetList

<a id="opIdC4WX1APIFeaturesActivityGetGetList"></a>

> Code samples

```shell
curl --request GET \
  --url https://localhost:7055/api/activity \
  --header 'Accept: application/json'
```

`GET /api/activity`

*Get Activity List*

Get a list of activities

<h3 id="c4wx1apifeaturesactivitygetgetlist-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|PageIndex|query|integer(int32)|false|none|
|PageSize|query|integer(int32)|false|none|
|OrderBy|query|string|false|none|

> Example responses

> 200 Response

```json
[
  {
    "ActivityID": 0,
    "ProblemListID_FK": 0,
    "DiseaseID_FK": 0,
    "ActivityDetail": "string",
    "IsDeleted": true,
    "CreatedDate": "2019-08-24T14:15:22Z",
    "CreatedBy_FK": 0,
    "ModifiedDate": "2019-08-24T14:15:22Z",
    "ModifiedBy_FK": 0,
    "DiseaseSubInfoID_FK": 0,
    "CanDelete": true
  }
]
```

<h3 id="c4wx1apifeaturesactivitygetgetlist-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Activity list retrieved successfully|Inline|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<h3 id="c4wx1apifeaturesactivitygetgetlist-responseschema">Response Schema</h3>

Status Code **200**

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[[C4WX1APIFeaturesActivityDtosActivityDto](#schemac4wx1apifeaturesactivitydtosactivitydto)]|false|none|none|
|» ActivityID|integer(int32)|false|none|none|
|» ProblemListID_FK|integer(int32)|false|none|none|
|» DiseaseID_FK|integer(int32)|false|none|none|
|» ActivityDetail|string|false|none|none|
|» IsDeleted|boolean|false|none|none|
|» CreatedDate|string(date-time)¦null|false|none|none|
|» CreatedBy_FK|integer(int32)¦null|false|none|none|
|» ModifiedDate|string(date-time)¦null|false|none|none|
|» ModifiedBy_FK|integer(int32)¦null|false|none|none|
|» DiseaseSubInfoID_FK|integer(int32)¦null|false|none|none|
|» CanDelete|boolean|false|none|none|

<aside class="success">
This operation does not require authentication
</aside>

## C4WX1APIFeaturesActivityCreateCreate

<a id="opIdC4WX1APIFeaturesActivityCreateCreate"></a>

> Code samples

```shell
curl --request POST \
  --url https://localhost:7055/api/activity \
  --header 'Accept: application/problem+json' \
  --header 'Content-Type: application/json' \
  --data '{"ProblemListID_FK":1,"DiseaseID_FK":1,"ActivityDetail":"Activity Detail","DiseaseSubInfoID_FK":1,"UserId":1}'
```

`POST /api/activity`

*Create Activity*

Create a new Activity

> Body parameter

```json
{
  "ProblemListID_FK": 1,
  "DiseaseID_FK": 1,
  "ActivityDetail": "Activity Detail",
  "DiseaseSubInfoID_FK": 1,
  "UserId": 1
}
```

<h3 id="c4wx1apifeaturesactivitycreatecreate-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[C4WX1APIFeaturesActivityDtosCreateActivityDto](#schemac4wx1apifeaturesactivitydtoscreateactivitydto)|true|none|

> Example responses

> 500 Response

```json
{
  "Status": "Internal Server Error!",
  "Code": 500,
  "Reason": "Something unexpected has happened",
  "Note": "See application log for stack trace."
}
```

<h3 id="c4wx1apifeaturesactivitycreatecreate-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|204|[No Content](https://tools.ietf.org/html/rfc7231#section-6.3.5)|Activity created successfully|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## C4WX1APIFeaturesActivityDeleteDelete

<a id="opIdC4WX1APIFeaturesActivityDeleteDelete"></a>

> Code samples

```shell
curl --request DELETE \
  --url https://localhost:7055/api/activity/0 \
  --header 'Accept: application/problem+json' \
  --header 'Content-Type: */*' \
  --data '{"UserId":0}'
```

`DELETE /api/activity/{id}`

*Delete Activity*

Delete an existing Activity

> Body parameter

```json
{
  "UserId": 0
}
```

<h3 id="c4wx1apifeaturesactivitydeletedelete-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|integer(int32)|true|none|
|body|body|[C4WX1APIFeaturesSharedDtosDeleteByIdDto](#schemac4wx1apifeaturesshareddtosdeletebyiddto)|true|none|

> Example responses

> 500 Response

```json
{
  "Status": "Internal Server Error!",
  "Code": 500,
  "Reason": "Something unexpected has happened",
  "Note": "See application log for stack trace."
}
```

<h3 id="c4wx1apifeaturesactivitydeletedelete-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|204|[No Content](https://tools.ietf.org/html/rfc7231#section-6.3.5)|Activity deleted successfully|None|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Activity not found|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

# Schemas

<h2 id="tocS_FastEndpointsInternalErrorResponse">FastEndpointsInternalErrorResponse</h2>
<!-- backwards compatibility -->
<a id="schemafastendpointsinternalerrorresponse"></a>
<a id="schema_FastEndpointsInternalErrorResponse"></a>
<a id="tocSfastendpointsinternalerrorresponse"></a>
<a id="tocsfastendpointsinternalerrorresponse"></a>

```json
{
  "Status": "Internal Server Error!",
  "Code": 500,
  "Reason": "Something unexpected has happened",
  "Note": "See application log for stack trace."
}

```

the dto used to send an error response to the client when an unhandled exception occurs on the server

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|Status|string|false|none|error status|
|Code|integer(int32)|false|none|http status code of the error response|
|Reason|string|false|none|the reason for the error|
|Note|string|false|none|additional information or instructions|

<h2 id="tocS_C4WX1APIFeaturesSysConfigDtosUpdateSysConfigDto">C4WX1APIFeaturesSysConfigDtosUpdateSysConfigDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturessysconfigdtosupdatesysconfigdto"></a>
<a id="schema_C4WX1APIFeaturesSysConfigDtosUpdateSysConfigDto"></a>
<a id="tocSc4wx1apifeaturessysconfigdtosupdatesysconfigdto"></a>
<a id="tocsc4wx1apifeaturessysconfigdtosupdatesysconfigdto"></a>

```json
{
  "ConfigName": "string",
  "ConfigValue": "string",
  "UserID": 0
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|ConfigName|string|false|none|none|
|ConfigValue|string|false|none|none|
|UserID|integer(int32)|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesSysConfigDtosSysConfigDto">C4WX1APIFeaturesSysConfigDtosSysConfigDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturessysconfigdtossysconfigdto"></a>
<a id="schema_C4WX1APIFeaturesSysConfigDtosSysConfigDto"></a>
<a id="tocSc4wx1apifeaturessysconfigdtossysconfigdto"></a>
<a id="tocsc4wx1apifeaturessysconfigdtossysconfigdto"></a>

```json
{
  "ConfigName": "string",
  "ConfigValue": "string",
  "ModifiedDate": "2019-08-24T14:15:22Z",
  "ModifiedBy_FK": 0,
  "IsConfigurable": true,
  "Description": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|ConfigName|string|false|none|none|
|ConfigValue|string¦null|false|none|none|
|ModifiedDate|string(date-time)¦null|false|none|none|
|ModifiedBy_FK|integer(int32)¦null|false|none|none|
|IsConfigurable|boolean¦null|false|none|none|
|Description|string¦null|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesSysConfigDtosGetSysConfigDto">C4WX1APIFeaturesSysConfigDtosGetSysConfigDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturessysconfigdtosgetsysconfigdto"></a>
<a id="schema_C4WX1APIFeaturesSysConfigDtosGetSysConfigDto"></a>
<a id="tocSc4wx1apifeaturessysconfigdtosgetsysconfigdto"></a>
<a id="tocsc4wx1apifeaturessysconfigdtosgetsysconfigdto"></a>

```json
{}

```

### Properties

*None*

<h2 id="tocS_C4WX1APIFeaturesSysConfigDtosGetSysConfigListDto">C4WX1APIFeaturesSysConfigDtosGetSysConfigListDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturessysconfigdtosgetsysconfiglistdto"></a>
<a id="schema_C4WX1APIFeaturesSysConfigDtosGetSysConfigListDto"></a>
<a id="tocSc4wx1apifeaturessysconfigdtosgetsysconfiglistdto"></a>
<a id="tocsc4wx1apifeaturessysconfigdtosgetsysconfiglistdto"></a>

```json
{}

```

### Properties

allOf

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[C4WX1APIFeaturesSharedDtosGetListDto](#schemac4wx1apifeaturesshareddtosgetlistdto)|false|none|none|

and

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|object|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesSharedDtosGetListDto">C4WX1APIFeaturesSharedDtosGetListDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesshareddtosgetlistdto"></a>
<a id="schema_C4WX1APIFeaturesSharedDtosGetListDto"></a>
<a id="tocSc4wx1apifeaturesshareddtosgetlistdto"></a>
<a id="tocsc4wx1apifeaturesshareddtosgetlistdto"></a>

```json
{}

```

### Properties

*None*

<h2 id="tocS_C4WX1APIFeaturesSysConfigDtosCreateSysConfigDto">C4WX1APIFeaturesSysConfigDtosCreateSysConfigDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturessysconfigdtoscreatesysconfigdto"></a>
<a id="schema_C4WX1APIFeaturesSysConfigDtosCreateSysConfigDto"></a>
<a id="tocSc4wx1apifeaturessysconfigdtoscreatesysconfigdto"></a>
<a id="tocsc4wx1apifeaturessysconfigdtoscreatesysconfigdto"></a>

```json
{
  "ConfigName": "Config Name",
  "ConfigValue": "Config Value",
  "IsConfigurable": false,
  "Description": "Description"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|ConfigName|string|false|none|none|
|ConfigValue|string¦null|false|none|none|
|IsConfigurable|boolean¦null|false|none|none|
|Description|string¦null|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesChatDtosChatDto">C4WX1APIFeaturesChatDtosChatDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeatureschatdtoschatdto"></a>
<a id="schema_C4WX1APIFeaturesChatDtosChatDto"></a>
<a id="tocSc4wx1apifeatureschatdtoschatdto"></a>
<a id="tocsc4wx1apifeatureschatdtoschatdto"></a>

```json
{
  "ChatID": 0,
  "Comment": "string",
  "Attachment": "string",
  "Attachment_Physical": "string",
  "ParentID_FK": 0,
  "PatientID_FK": 0,
  "CreatedDate": "2019-08-24T14:15:22Z",
  "CreatedBy_FK": 0,
  "IsDeleted": true,
  "Family": true,
  "UserData": {
    "UserId": 0,
    "Firstname": "string",
    "Lastname": "string",
    "Photo": "string"
  },
  "PatientData": {
    "PatientID": 0,
    "Firstname": "string",
    "Lastname": "string",
    "Photo": "string"
  },
  "CommentList": [
    {
      "ChatID": 0,
      "Comment": "string",
      "Attachment": "string",
      "Attachment_Physical": "string",
      "ParentID_FK": 0,
      "PatientID_FK": 0,
      "CreatedDate": "2019-08-24T14:15:22Z",
      "CreatedBy_FK": 0,
      "IsDeleted": true,
      "Family": true,
      "UserData": {
        "UserId": 0,
        "Firstname": "string",
        "Lastname": "string",
        "Photo": "string"
      },
      "PatientData": {
        "PatientID": 0,
        "Firstname": "string",
        "Lastname": "string",
        "Photo": "string"
      },
      "CommentList": []
    }
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|ChatID|integer(int32)|false|none|none|
|Comment|string¦null|false|none|none|
|Attachment|string¦null|false|none|none|
|Attachment_Physical|string¦null|false|none|none|
|ParentID_FK|integer(int32)¦null|false|none|none|
|PatientID_FK|integer(int32)¦null|false|none|none|
|CreatedDate|string(date-time)|false|none|none|
|CreatedBy_FK|integer(int32)|false|none|none|
|IsDeleted|boolean|false|none|none|
|Family|boolean¦null|false|none|none|
|UserData|[C4WX1APIFeaturesChatDtosChatUserDto](#schemac4wx1apifeatureschatdtoschatuserdto)¦null|false|none|none|
|PatientData|[C4WX1APIFeaturesChatDtosChatPatientDto](#schemac4wx1apifeatureschatdtoschatpatientdto)¦null|false|none|none|
|CommentList|[[C4WX1APIFeaturesChatDtosChatDto](#schemac4wx1apifeatureschatdtoschatdto)]|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesChatDtosChatUserDto">C4WX1APIFeaturesChatDtosChatUserDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeatureschatdtoschatuserdto"></a>
<a id="schema_C4WX1APIFeaturesChatDtosChatUserDto"></a>
<a id="tocSc4wx1apifeatureschatdtoschatuserdto"></a>
<a id="tocsc4wx1apifeatureschatdtoschatuserdto"></a>

```json
{
  "UserId": 0,
  "Firstname": "string",
  "Lastname": "string",
  "Photo": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|UserId|integer(int32)|false|none|none|
|Firstname|string|false|none|none|
|Lastname|string|false|none|none|
|Photo|string¦null|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesChatDtosChatPatientDto">C4WX1APIFeaturesChatDtosChatPatientDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeatureschatdtoschatpatientdto"></a>
<a id="schema_C4WX1APIFeaturesChatDtosChatPatientDto"></a>
<a id="tocSc4wx1apifeatureschatdtoschatpatientdto"></a>
<a id="tocsc4wx1apifeatureschatdtoschatpatientdto"></a>

```json
{
  "PatientID": 0,
  "Firstname": "string",
  "Lastname": "string",
  "Photo": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|PatientID|integer(int32)|false|none|none|
|Firstname|string|false|none|none|
|Lastname|string|false|none|none|
|Photo|string¦null|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesSharedDtosGetByIdDto">C4WX1APIFeaturesSharedDtosGetByIdDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesshareddtosgetbyiddto"></a>
<a id="schema_C4WX1APIFeaturesSharedDtosGetByIdDto"></a>
<a id="tocSc4wx1apifeaturesshareddtosgetbyiddto"></a>
<a id="tocsc4wx1apifeaturesshareddtosgetbyiddto"></a>

```json
{}

```

### Properties

*None*

<h2 id="tocS_C4WX1APIFeaturesChatDtosGetCanLoadMoreChatDto">C4WX1APIFeaturesChatDtosGetCanLoadMoreChatDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeatureschatdtosgetcanloadmorechatdto"></a>
<a id="schema_C4WX1APIFeaturesChatDtosGetCanLoadMoreChatDto"></a>
<a id="tocSc4wx1apifeatureschatdtosgetcanloadmorechatdto"></a>
<a id="tocsc4wx1apifeatureschatdtosgetcanloadmorechatdto"></a>

```json
{}

```

### Properties

*None*

<h2 id="tocS_C4WX1APIFeaturesChatDtosGetChatListDto">C4WX1APIFeaturesChatDtosGetChatListDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeatureschatdtosgetchatlistdto"></a>
<a id="schema_C4WX1APIFeaturesChatDtosGetChatListDto"></a>
<a id="tocSc4wx1apifeatureschatdtosgetchatlistdto"></a>
<a id="tocsc4wx1apifeatureschatdtosgetchatlistdto"></a>

```json
{}

```

### Properties

*None*

<h2 id="tocS_C4WX1APIFeaturesSharedDtosDeleteByIdDto">C4WX1APIFeaturesSharedDtosDeleteByIdDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesshareddtosdeletebyiddto"></a>
<a id="schema_C4WX1APIFeaturesSharedDtosDeleteByIdDto"></a>
<a id="tocSc4wx1apifeaturesshareddtosdeletebyiddto"></a>
<a id="tocsc4wx1apifeaturesshareddtosdeletebyiddto"></a>

```json
{
  "UserId": 0
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|UserId|integer(int32)|false|none|none|

<h2 id="tocS_FastEndpointsErrorResponse">FastEndpointsErrorResponse</h2>
<!-- backwards compatibility -->
<a id="schemafastendpointserrorresponse"></a>
<a id="schema_FastEndpointsErrorResponse"></a>
<a id="tocSfastendpointserrorresponse"></a>
<a id="tocsfastendpointserrorresponse"></a>

```json
{
  "StatusCode": 400,
  "Message": "One or more errors occurred!",
  "Errors": {
    "property1": [
      "string"
    ],
    "property2": [
      "string"
    ]
  }
}

```

the dto used to send an error response to the client

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|StatusCode|integer(int32)|false|none|the http status code sent to the client. default is 400.|
|Message|string|false|none|the message for the error response|
|Errors|object|false|none|the collection of errors for the current context|
|» **additionalProperties**|[string]|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesChatDtosCreateChatDto">C4WX1APIFeaturesChatDtosCreateChatDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeatureschatdtoscreatechatdto"></a>
<a id="schema_C4WX1APIFeaturesChatDtosCreateChatDto"></a>
<a id="tocSc4wx1apifeatureschatdtoscreatechatdto"></a>
<a id="tocsc4wx1apifeatureschatdtoscreatechatdto"></a>

```json
{
  "Attachment": "Attachment",
  "Attachment_Physical": "Attachment_Physical",
  "CreatedBy_FK": 1,
  "ParentID_FK": 1,
  "PatientID_FK": 1,
  "Comment": "Comment",
  "Family": true
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|Attachment|string¦null|false|none|none|
|Attachment_Physical|string¦null|false|none|none|
|CreatedBy_FK|integer(int32)|false|none|none|
|ParentID_FK|integer(int32)¦null|false|none|none|
|PatientID_FK|integer(int32)¦null|false|none|none|
|Comment|string¦null|false|none|none|
|Family|boolean¦null|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesCarePlanSubGoalDtosUpdateCarePlanSubGoalDto">C4WX1APIFeaturesCarePlanSubGoalDtosUpdateCarePlanSubGoalDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturescareplansubgoaldtosupdatecareplansubgoaldto"></a>
<a id="schema_C4WX1APIFeaturesCarePlanSubGoalDtosUpdateCarePlanSubGoalDto"></a>
<a id="tocSc4wx1apifeaturescareplansubgoaldtosupdatecareplansubgoaldto"></a>
<a id="tocsc4wx1apifeaturescareplansubgoaldtosupdatecareplansubgoaldto"></a>

```json
{
  "CarePlanSubID_FK": 1,
  "CarePlanSubGoalName": "care plan sub goal",
  "UserId": 1
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|CarePlanSubID_FK|integer(int32)|false|none|none|
|CarePlanSubGoalName|string¦null|false|none|none|
|UserId|integer(int32)|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesCarePlanSubGoalDtosCarePlanSubGoalDto">C4WX1APIFeaturesCarePlanSubGoalDtosCarePlanSubGoalDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturescareplansubgoaldtoscareplansubgoaldto"></a>
<a id="schema_C4WX1APIFeaturesCarePlanSubGoalDtosCarePlanSubGoalDto"></a>
<a id="tocSc4wx1apifeaturescareplansubgoaldtoscareplansubgoaldto"></a>
<a id="tocsc4wx1apifeaturescareplansubgoaldtoscareplansubgoaldto"></a>

```json
{
  "CarePlanSubGoalID": 0,
  "ScoreTypeID": 0,
  "Score1": 0,
  "Score2": 0,
  "CarePlanSubGoalName": "string",
  "IsDeleted": true,
  "CanDelete": true
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|CarePlanSubGoalID|integer(int32)|false|none|none|
|ScoreTypeID|integer(int32)¦null|false|none|none|
|Score1|number(decimal)¦null|false|none|none|
|Score2|number(decimal)¦null|false|none|none|
|CarePlanSubGoalName|string¦null|false|none|none|
|IsDeleted|boolean¦null|false|none|none|
|CanDelete|boolean|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesCarePlanSubGoalDtosCreateCarePlanSubGoalDto">C4WX1APIFeaturesCarePlanSubGoalDtosCreateCarePlanSubGoalDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturescareplansubgoaldtoscreatecareplansubgoaldto"></a>
<a id="schema_C4WX1APIFeaturesCarePlanSubGoalDtosCreateCarePlanSubGoalDto"></a>
<a id="tocSc4wx1apifeaturescareplansubgoaldtoscreatecareplansubgoaldto"></a>
<a id="tocsc4wx1apifeaturescareplansubgoaldtoscreatecareplansubgoaldto"></a>

```json
{
  "CarePlanSubID_FK": 1,
  "CarePlanSubGoalName": "care plan sub goal",
  "UserId": 1
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|CarePlanSubID_FK|integer(int32)|false|none|none|
|CarePlanSubGoalName|string¦null|false|none|none|
|UserId|integer(int32)|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesC4WImageDtosUpdateC4WImageDto">C4WX1APIFeaturesC4WImageDtosUpdateC4WImageDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesc4wimagedtosupdatec4wimagedto"></a>
<a id="schema_C4WX1APIFeaturesC4WImageDtosUpdateC4WImageDto"></a>
<a id="tocSc4wx1apifeaturesc4wimagedtosupdatec4wimagedto"></a>
<a id="tocsc4wx1apifeaturesc4wimagedtosupdatec4wimagedto"></a>

```json
{
  "WoundImageName": "wound image name",
  "WoundImageData": "wound image data",
  "WoundBedImageName": "wound bed image name",
  "WoundBedImageData": "wound bed image data",
  "TissueImageName": "tissue image name",
  "TissueImageData": "tissue image data",
  "DepthImageName": "depth image name",
  "DepthImageData": "depth image data",
  "UserId": 1
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|WoundImageName|string¦null|false|none|none|
|WoundImageData|string¦null|false|none|none|
|WoundBedImageName|string¦null|false|none|none|
|WoundBedImageData|string¦null|false|none|none|
|TissueImageName|string¦null|false|none|none|
|TissueImageData|string¦null|false|none|none|
|DepthImageName|string¦null|false|none|none|
|DepthImageData|string¦null|false|none|none|
|UserId|integer(int32)|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesC4WImageDtosC4WImageDto">C4WX1APIFeaturesC4WImageDtosC4WImageDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesc4wimagedtosc4wimagedto"></a>
<a id="schema_C4WX1APIFeaturesC4WImageDtosC4WImageDto"></a>
<a id="tocSc4wx1apifeaturesc4wimagedtosc4wimagedto"></a>
<a id="tocsc4wx1apifeaturesc4wimagedtosc4wimagedto"></a>

```json
{
  "C4WImageId": 0,
  "WoundImageName": "string",
  "WoundImageData": "string",
  "WoundBedImageName": "string",
  "WoundBedImageData": "string",
  "TissueImageName": "string",
  "TissueImageData": "string",
  "DepthImageName": "string",
  "DepthImageData": "string",
  "IsDeleted": true,
  "CreatedDate": "2019-08-24T14:15:22Z",
  "CreatedBy_FK": 0,
  "ModifiedDate": "2019-08-24T14:15:22Z"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|C4WImageId|integer(int32)|false|none|none|
|WoundImageName|string¦null|false|none|none|
|WoundImageData|string¦null|false|none|none|
|WoundBedImageName|string¦null|false|none|none|
|WoundBedImageData|string¦null|false|none|none|
|TissueImageName|string¦null|false|none|none|
|TissueImageData|string¦null|false|none|none|
|DepthImageName|string¦null|false|none|none|
|DepthImageData|string¦null|false|none|none|
|IsDeleted|boolean|false|none|none|
|CreatedDate|string(date-time)|false|none|none|
|CreatedBy_FK|integer(int32)|false|none|none|
|ModifiedDate|string(date-time)¦null|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesC4WImageDtosGetC4WImageCountByDateDto">C4WX1APIFeaturesC4WImageDtosGetC4WImageCountByDateDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesc4wimagedtosgetc4wimagecountbydatedto"></a>
<a id="schema_C4WX1APIFeaturesC4WImageDtosGetC4WImageCountByDateDto"></a>
<a id="tocSc4wx1apifeaturesc4wimagedtosgetc4wimagecountbydatedto"></a>
<a id="tocsc4wx1apifeaturesc4wimagedtosgetc4wimagecountbydatedto"></a>

```json
{}

```

### Properties

*None*

<h2 id="tocS_C4WX1APIFeaturesC4WImageDtosGetC4WImageListDto">C4WX1APIFeaturesC4WImageDtosGetC4WImageListDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesc4wimagedtosgetc4wimagelistdto"></a>
<a id="schema_C4WX1APIFeaturesC4WImageDtosGetC4WImageListDto"></a>
<a id="tocSc4wx1apifeaturesc4wimagedtosgetc4wimagelistdto"></a>
<a id="tocsc4wx1apifeaturesc4wimagedtosgetc4wimagelistdto"></a>

```json
{}

```

### Properties

allOf

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[C4WX1APIFeaturesSharedDtosGetListDto](#schemac4wx1apifeaturesshareddtosgetlistdto)|false|none|none|

and

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|object|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesC4WImageDtosCreateC4WImageDto">C4WX1APIFeaturesC4WImageDtosCreateC4WImageDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesc4wimagedtoscreatec4wimagedto"></a>
<a id="schema_C4WX1APIFeaturesC4WImageDtosCreateC4WImageDto"></a>
<a id="tocSc4wx1apifeaturesc4wimagedtoscreatec4wimagedto"></a>
<a id="tocsc4wx1apifeaturesc4wimagedtoscreatec4wimagedto"></a>

```json
{
  "WoundImageName": "wound image name",
  "WoundImageData": "wound image data",
  "WoundBedImageName": "wound bed image name",
  "WoundBedImageData": "wound bed image data",
  "TissueImageName": "tissue image name",
  "TissueImageData": "tissue image data",
  "DepthImageName": "depth image name",
  "DepthImageData": "depth image data",
  "UserId": 1
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|WoundImageName|string¦null|false|none|none|
|WoundImageData|string¦null|false|none|none|
|WoundBedImageName|string¦null|false|none|none|
|WoundBedImageData|string¦null|false|none|none|
|TissueImageName|string¦null|false|none|none|
|TissueImageData|string¦null|false|none|none|
|DepthImageName|string¦null|false|none|none|
|DepthImageData|string¦null|false|none|none|
|UserId|integer(int32)|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesC4WDeviceTokenDtosUpdateC4WDeviceTokenDto">C4WX1APIFeaturesC4WDeviceTokenDtosUpdateC4WDeviceTokenDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesc4wdevicetokendtosupdatec4wdevicetokendto"></a>
<a id="schema_C4WX1APIFeaturesC4WDeviceTokenDtosUpdateC4WDeviceTokenDto"></a>
<a id="tocSc4wx1apifeaturesc4wdevicetokendtosupdatec4wdevicetokendto"></a>
<a id="tocsc4wx1apifeaturesc4wdevicetokendtosupdatec4wdevicetokendto"></a>

```json
{
  "OldDeviceToken": "Old token",
  "NewDeviceToken": "New token",
  "ClientEnvironment": "test env",
  "Device": "IPhone",
  "UserId": 1
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|OldDeviceToken|string¦null|false|none|none|
|NewDeviceToken|string¦null|false|none|none|
|ClientEnvironment|string¦null|false|none|none|
|Device|string¦null|false|none|none|
|UserId|integer(int32)|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesC4WDeviceTokenDtosC4WDeviceTokenDto">C4WX1APIFeaturesC4WDeviceTokenDtosC4WDeviceTokenDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesc4wdevicetokendtosc4wdevicetokendto"></a>
<a id="schema_C4WX1APIFeaturesC4WDeviceTokenDtosC4WDeviceTokenDto"></a>
<a id="tocSc4wx1apifeaturesc4wdevicetokendtosc4wdevicetokendto"></a>
<a id="tocsc4wx1apifeaturesc4wdevicetokendtosc4wdevicetokendto"></a>

```json
{
  "C4WDeviceTokenId": 0,
  "OldDeviceToken": "string",
  "NewDeviceToken": "string",
  "ClientEnvironment": "string",
  "Device": "string",
  "IsDeleted": true,
  "CreatedDate": "2019-08-24T14:15:22Z",
  "CreatedBy_FK": 0,
  "ModifiedDate": "2019-08-24T14:15:22Z",
  "ModifiedBy_FK": 0
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|C4WDeviceTokenId|integer(int32)|false|none|none|
|OldDeviceToken|string¦null|false|none|none|
|NewDeviceToken|string¦null|false|none|none|
|ClientEnvironment|string¦null|false|none|none|
|Device|string¦null|false|none|none|
|IsDeleted|boolean|false|none|none|
|CreatedDate|string(date-time)|false|none|none|
|CreatedBy_FK|integer(int32)|false|none|none|
|ModifiedDate|string(date-time)¦null|false|none|none|
|ModifiedBy_FK|integer(int32)¦null|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesC4WDeviceTokenDtosGetC4WDeviceTokenByOldDeviceTokenDto">C4WX1APIFeaturesC4WDeviceTokenDtosGetC4WDeviceTokenByOldDeviceTokenDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesc4wdevicetokendtosgetc4wdevicetokenbyolddevicetokendto"></a>
<a id="schema_C4WX1APIFeaturesC4WDeviceTokenDtosGetC4WDeviceTokenByOldDeviceTokenDto"></a>
<a id="tocSc4wx1apifeaturesc4wdevicetokendtosgetc4wdevicetokenbyolddevicetokendto"></a>
<a id="tocsc4wx1apifeaturesc4wdevicetokendtosgetc4wdevicetokenbyolddevicetokendto"></a>

```json
{}

```

### Properties

*None*

<h2 id="tocS_C4WX1APIFeaturesC4WDeviceTokenDtosCreateC4WDeviceTokenDto">C4WX1APIFeaturesC4WDeviceTokenDtosCreateC4WDeviceTokenDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesc4wdevicetokendtoscreatec4wdevicetokendto"></a>
<a id="schema_C4WX1APIFeaturesC4WDeviceTokenDtosCreateC4WDeviceTokenDto"></a>
<a id="tocSc4wx1apifeaturesc4wdevicetokendtoscreatec4wdevicetokendto"></a>
<a id="tocsc4wx1apifeaturesc4wdevicetokendtoscreatec4wdevicetokendto"></a>

```json
{
  "OldDeviceToken": "Old Token",
  "NewDeviceToken": "New Token",
  "ClientEnvironment": "test env",
  "Device": "Iphone",
  "UserId": 1
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|OldDeviceToken|string¦null|false|none|none|
|NewDeviceToken|string¦null|false|none|none|
|ClientEnvironment|string¦null|false|none|none|
|Device|string¦null|false|none|none|
|UserId|integer(int32)|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesBranchDtosUpdateBranchDto">C4WX1APIFeaturesBranchDtosUpdateBranchDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesbranchdtosupdatebranchdto"></a>
<a id="schema_C4WX1APIFeaturesBranchDtosUpdateBranchDto"></a>
<a id="tocSc4wx1apifeaturesbranchdtosupdatebranchdto"></a>
<a id="tocsc4wx1apifeaturesbranchdtosupdatebranchdto"></a>

```json
{
  "BranchName": "BranchName",
  "Address1": "Address1",
  "Address2": "Address2",
  "Address3": "Address3",
  "Contact": "Contact",
  "Email": "test@test.com",
  "Status": "Active",
  "CurrencyID_FK": 1,
  "UserId": 1,
  "UserDataList": [
    {
      "UserId": 1,
      "FirstName": null,
      "LastName": null
    }
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|BranchName|string|false|none|none|
|Address1|string¦null|false|none|none|
|Address2|string¦null|false|none|none|
|Address3|string¦null|false|none|none|
|Contact|string¦null|false|none|none|
|Email|string¦null|false|none|none|
|Status|string|false|none|none|
|CurrencyID_FK|integer(int32)¦null|false|none|none|
|UserId|integer(int32)|false|none|none|
|UserDataList|[[C4WX1APIFeaturesBranchDtosBranchUserDto](#schemac4wx1apifeaturesbranchdtosbranchuserdto)]|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesBranchDtosBranchUserDto">C4WX1APIFeaturesBranchDtosBranchUserDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesbranchdtosbranchuserdto"></a>
<a id="schema_C4WX1APIFeaturesBranchDtosBranchUserDto"></a>
<a id="tocSc4wx1apifeaturesbranchdtosbranchuserdto"></a>
<a id="tocsc4wx1apifeaturesbranchdtosbranchuserdto"></a>

```json
{
  "UserId": 0,
  "FirstName": "string",
  "LastName": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|UserId|integer(int32)|false|none|none|
|FirstName|string|false|none|none|
|LastName|string|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesBranchDtosBranchDto">C4WX1APIFeaturesBranchDtosBranchDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesbranchdtosbranchdto"></a>
<a id="schema_C4WX1APIFeaturesBranchDtosBranchDto"></a>
<a id="tocSc4wx1apifeaturesbranchdtosbranchdto"></a>
<a id="tocsc4wx1apifeaturesbranchdtosbranchdto"></a>

```json
{
  "BranchID": 0,
  "BranchName": "string",
  "Address1": "string",
  "Address2": "string",
  "Address3": "string",
  "Contact": "string",
  "Email": "string",
  "Status": "string",
  "IsSystemUsed": true,
  "CurrencyID_FK": 0,
  "CurrencyName": "string",
  "CanDelete": true,
  "UserDataList": [
    {
      "UserId": 0,
      "FirstName": "string",
      "LastName": "string"
    }
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|BranchID|integer(int32)|false|none|none|
|BranchName|string|false|none|none|
|Address1|string¦null|false|none|none|
|Address2|string¦null|false|none|none|
|Address3|string¦null|false|none|none|
|Contact|string¦null|false|none|none|
|Email|string¦null|false|none|none|
|Status|string|false|none|none|
|IsSystemUsed|boolean|false|none|none|
|CurrencyID_FK|integer(int32)¦null|false|none|none|
|CurrencyName|string|false|none|none|
|CanDelete|boolean|false|none|none|
|UserDataList|[[C4WX1APIFeaturesBranchDtosBranchUserDto](#schemac4wx1apifeaturesbranchdtosbranchuserdto)]|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesBranchDtosDeleteBranchDto">C4WX1APIFeaturesBranchDtosDeleteBranchDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesbranchdtosdeletebranchdto"></a>
<a id="schema_C4WX1APIFeaturesBranchDtosDeleteBranchDto"></a>
<a id="tocSc4wx1apifeaturesbranchdtosdeletebranchdto"></a>
<a id="tocsc4wx1apifeaturesbranchdtosdeletebranchdto"></a>

```json
{
  "UserId": 1
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|UserId|integer(int32)|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesBranchDtosCreateBranchDto">C4WX1APIFeaturesBranchDtosCreateBranchDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesbranchdtoscreatebranchdto"></a>
<a id="schema_C4WX1APIFeaturesBranchDtosCreateBranchDto"></a>
<a id="tocSc4wx1apifeaturesbranchdtoscreatebranchdto"></a>
<a id="tocsc4wx1apifeaturesbranchdtoscreatebranchdto"></a>

```json
{
  "BranchID": 0,
  "BranchName": "BranchName",
  "Address1": "Address1",
  "Address2": "Address2",
  "Address3": "Address3",
  "Contact": "Contact",
  "Email": "test@test.com",
  "Status": "Active",
  "CurrencyID_FK": 1,
  "UserId": 1,
  "UserDataList": [
    {
      "UserId": 1,
      "FirstName": null,
      "LastName": null
    }
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|BranchID|integer(int32)|false|none|none|
|BranchName|string|false|none|none|
|Address1|string¦null|false|none|none|
|Address2|string¦null|false|none|none|
|Address3|string¦null|false|none|none|
|Contact|string¦null|false|none|none|
|Email|string¦null|false|none|none|
|Status|string|false|none|none|
|CurrencyID_FK|integer(int32)¦null|false|none|none|
|UserId|integer(int32)|false|none|none|
|UserDataList|[[C4WX1APIFeaturesBranchDtosBranchUserDto](#schemac4wx1apifeaturesbranchdtosbranchuserdto)]|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesBillingProposalDtosUpdateBillingProposalDto">C4WX1APIFeaturesBillingProposalDtosUpdateBillingProposalDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesbillingproposaldtosupdatebillingproposaldto"></a>
<a id="schema_C4WX1APIFeaturesBillingProposalDtosUpdateBillingProposalDto"></a>
<a id="tocSc4wx1apifeaturesbillingproposaldtosupdatebillingproposaldto"></a>
<a id="tocsc4wx1apifeaturesbillingproposaldtosupdatebillingproposaldto"></a>

```json
{
  "PatientID_FK": 1,
  "Title": "Title",
  "SendEmail": true,
  "EmailPatient": true,
  "EmailTo": "test-to@gmail.com",
  "EmailCC": "test-cc@gmail.com",
  "EmailBCC": "test-bcc@gmail.com",
  "CurrencyID_FK": 1,
  "Status": "Active",
  "GroupNumber": "1",
  "Version": 1,
  "ProposalType": "ProposalType",
  "UserId": 1,
  "ServiceList": [
    {
      "BillingInvoiceServiceID": 0,
      "BillingProposalID_FK": 0,
      "ServiceID_FK": 1,
      "CategoryId": 0,
      "Title": null,
      "StartDate": "2025-02-27T23:51:34.5331158+08:00",
      "EndDate": "2025-02-27T23:51:34.5365272+08:00",
      "UnitCost": 0,
      "Duration1": "Duration1",
      "Duration2": "Duration2",
      "Visit": 1,
      "Session": 0,
      "Discount": 0,
      "ServiceDescription": "ServiceDescription",
      "CategoryName": null
    }
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|PatientID_FK|integer(int32)|false|none|none|
|Title|string|false|none|none|
|SendEmail|boolean¦null|false|none|none|
|EmailPatient|boolean¦null|false|none|none|
|EmailTo|string¦null|false|none|none|
|EmailCC|string¦null|false|none|none|
|EmailBCC|string¦null|false|none|none|
|CurrencyID_FK|integer(int32)|false|none|none|
|Status|string|false|none|none|
|GroupNumber|string|false|none|none|
|Version|integer|false|none|none|
|ProposalType|string|false|none|none|
|UserId|integer(int32)|false|none|none|
|ServiceList|[[C4WX1APIFeaturesBillingProposalDtosBillingProposalServiceDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposalservicedto)]|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesBillingProposalDtosBillingProposalServiceDto">C4WX1APIFeaturesBillingProposalDtosBillingProposalServiceDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesbillingproposaldtosbillingproposalservicedto"></a>
<a id="schema_C4WX1APIFeaturesBillingProposalDtosBillingProposalServiceDto"></a>
<a id="tocSc4wx1apifeaturesbillingproposaldtosbillingproposalservicedto"></a>
<a id="tocsc4wx1apifeaturesbillingproposaldtosbillingproposalservicedto"></a>

```json
{
  "BillingInvoiceServiceID": 0,
  "BillingProposalID_FK": 0,
  "ServiceID_FK": 0,
  "CategoryId": 0,
  "Title": "string",
  "StartDate": "2019-08-24T14:15:22Z",
  "EndDate": "2019-08-24T14:15:22Z",
  "UnitCost": 0,
  "Duration1": "string",
  "Duration2": "string",
  "Visit": 0,
  "Session": 0,
  "Discount": 0,
  "ServiceDescription": "string",
  "CategoryName": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|BillingInvoiceServiceID|integer(int32)|false|none|none|
|BillingProposalID_FK|integer(int32)|false|none|none|
|ServiceID_FK|integer(int32)|false|none|none|
|CategoryId|integer(int32)|false|none|none|
|Title|string|false|none|none|
|StartDate|string(date-time)|false|none|none|
|EndDate|string(date-time)|false|none|none|
|UnitCost|number(decimal)|false|none|none|
|Duration1|string¦null|false|none|none|
|Duration2|string¦null|false|none|none|
|Visit|integer(int32)|false|none|none|
|Session|integer(int32)|false|none|none|
|Discount|number(decimal)|false|none|none|
|ServiceDescription|string¦null|false|none|none|
|CategoryName|string|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesBillingProposalDtosUpdateBillingProposalStatusDto">C4WX1APIFeaturesBillingProposalDtosUpdateBillingProposalStatusDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesbillingproposaldtosupdatebillingproposalstatusdto"></a>
<a id="schema_C4WX1APIFeaturesBillingProposalDtosUpdateBillingProposalStatusDto"></a>
<a id="tocSc4wx1apifeaturesbillingproposaldtosupdatebillingproposalstatusdto"></a>
<a id="tocsc4wx1apifeaturesbillingproposaldtosupdatebillingproposalstatusdto"></a>

```json
{
  "UserId": 1,
  "Status": "Success"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|UserId|integer(int32)|false|none|none|
|Status|string|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesBillingProposalDtosBillingProposalDto">C4WX1APIFeaturesBillingProposalDtosBillingProposalDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesbillingproposaldtosbillingproposaldto"></a>
<a id="schema_C4WX1APIFeaturesBillingProposalDtosBillingProposalDto"></a>
<a id="tocSc4wx1apifeaturesbillingproposaldtosbillingproposaldto"></a>
<a id="tocsc4wx1apifeaturesbillingproposaldtosbillingproposaldto"></a>

```json
{
  "BillingProposalID": 0,
  "PatientID_FK": 0,
  "ProposalNumber": "string",
  "Title": "string",
  "SendEmail": true,
  "EmailPatient": true,
  "EmailTo": "string",
  "EmailCC": "string",
  "EmailBCC": "string",
  "CurrencyID_FK": 0,
  "CurrencyCode": "string",
  "TotalCost": 0,
  "Status": "string",
  "GroupNumber": "string",
  "Version": 0,
  "CreatedDate": "2019-08-24T14:15:22Z",
  "CreatedBy_FK": 0,
  "ModifiedDate": "2019-08-24T14:15:22Z",
  "ModifiedBy_FK": 0,
  "IsDeleted": true,
  "ProposalType": "string",
  "PatientData": {
    "PatientID": 0,
    "FirstName": "string",
    "LastName": "string",
    "Photo": "string",
    "MailingAddress1": "string",
    "MailingAddress2": "string",
    "MailingAddress3": "string",
    "MailingPostalCode": "string",
    "Profile": {
      "Email": "string"
    }
  },
  "CreatedByData": {
    "UserId": 0,
    "FirstName": "string",
    "LastName": "string",
    "Photo": "string",
    "Email": "string"
  },
  "ModifiedByData": {
    "UserId": 0,
    "FirstName": "string",
    "LastName": "string",
    "Photo": "string",
    "Email": "string"
  },
  "ServiceList": [
    {
      "BillingInvoiceServiceID": 0,
      "BillingProposalID_FK": 0,
      "ServiceID_FK": 0,
      "CategoryId": 0,
      "Title": "string",
      "StartDate": "2019-08-24T14:15:22Z",
      "EndDate": "2019-08-24T14:15:22Z",
      "UnitCost": 0,
      "Duration1": "string",
      "Duration2": "string",
      "Visit": 0,
      "Session": 0,
      "Discount": 0,
      "ServiceDescription": "string",
      "CategoryName": "string"
    }
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|BillingProposalID|integer(int32)|false|none|none|
|PatientID_FK|integer(int32)|false|none|none|
|ProposalNumber|string|false|none|none|
|Title|string|false|none|none|
|SendEmail|boolean¦null|false|none|none|
|EmailPatient|boolean¦null|false|none|none|
|EmailTo|string¦null|false|none|none|
|EmailCC|string¦null|false|none|none|
|EmailBCC|string¦null|false|none|none|
|CurrencyID_FK|integer(int32)|false|none|none|
|CurrencyCode|string|false|none|none|
|TotalCost|number(decimal)|false|none|none|
|Status|string|false|none|none|
|GroupNumber|string|false|none|none|
|Version|integer|false|none|none|
|CreatedDate|string(date-time)|false|none|none|
|CreatedBy_FK|integer(int32)|false|none|none|
|ModifiedDate|string(date-time)¦null|false|none|none|
|ModifiedBy_FK|integer(int32)¦null|false|none|none|
|IsDeleted|boolean|false|none|none|
|ProposalType|string|false|none|none|
|PatientData|[C4WX1APIFeaturesBillingProposalDtosBillingProposalPatientDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposalpatientdto)|false|none|none|
|CreatedByData|[C4WX1APIFeaturesBillingProposalDtosBillingProposalUserDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposaluserdto)|false|none|none|
|ModifiedByData|[C4WX1APIFeaturesBillingProposalDtosBillingProposalUserDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposaluserdto)¦null|false|none|none|
|ServiceList|[[C4WX1APIFeaturesBillingProposalDtosBillingProposalServiceDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposalservicedto)]|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesBillingProposalDtosBillingProposalPatientDto">C4WX1APIFeaturesBillingProposalDtosBillingProposalPatientDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesbillingproposaldtosbillingproposalpatientdto"></a>
<a id="schema_C4WX1APIFeaturesBillingProposalDtosBillingProposalPatientDto"></a>
<a id="tocSc4wx1apifeaturesbillingproposaldtosbillingproposalpatientdto"></a>
<a id="tocsc4wx1apifeaturesbillingproposaldtosbillingproposalpatientdto"></a>

```json
{
  "PatientID": 0,
  "FirstName": "string",
  "LastName": "string",
  "Photo": "string",
  "MailingAddress1": "string",
  "MailingAddress2": "string",
  "MailingAddress3": "string",
  "MailingPostalCode": "string",
  "Profile": {
    "Email": "string"
  }
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|PatientID|integer(int32)|false|none|none|
|FirstName|string|false|none|none|
|LastName|string|false|none|none|
|Photo|string¦null|false|none|none|
|MailingAddress1|string¦null|false|none|none|
|MailingAddress2|string¦null|false|none|none|
|MailingAddress3|string¦null|false|none|none|
|MailingPostalCode|string¦null|false|none|none|
|Profile|[C4WX1APIFeaturesBillingProposalDtosBillingProposalPatientProfileDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposalpatientprofiledto)¦null|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesBillingProposalDtosBillingProposalPatientProfileDto">C4WX1APIFeaturesBillingProposalDtosBillingProposalPatientProfileDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesbillingproposaldtosbillingproposalpatientprofiledto"></a>
<a id="schema_C4WX1APIFeaturesBillingProposalDtosBillingProposalPatientProfileDto"></a>
<a id="tocSc4wx1apifeaturesbillingproposaldtosbillingproposalpatientprofiledto"></a>
<a id="tocsc4wx1apifeaturesbillingproposaldtosbillingproposalpatientprofiledto"></a>

```json
{
  "Email": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|Email|string¦null|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesBillingProposalDtosBillingProposalUserDto">C4WX1APIFeaturesBillingProposalDtosBillingProposalUserDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesbillingproposaldtosbillingproposaluserdto"></a>
<a id="schema_C4WX1APIFeaturesBillingProposalDtosBillingProposalUserDto"></a>
<a id="tocSc4wx1apifeaturesbillingproposaldtosbillingproposaluserdto"></a>
<a id="tocsc4wx1apifeaturesbillingproposaldtosbillingproposaluserdto"></a>

```json
{
  "UserId": 0,
  "FirstName": "string",
  "LastName": "string",
  "Photo": "string",
  "Email": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|UserId|integer(int32)|false|none|none|
|FirstName|string|false|none|none|
|LastName|string|false|none|none|
|Photo|string¦null|false|none|none|
|Email|string|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesBillingProposalDtosGetActiveBillingProposalListDto">C4WX1APIFeaturesBillingProposalDtosGetActiveBillingProposalListDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesbillingproposaldtosgetactivebillingproposallistdto"></a>
<a id="schema_C4WX1APIFeaturesBillingProposalDtosGetActiveBillingProposalListDto"></a>
<a id="tocSc4wx1apifeaturesbillingproposaldtosgetactivebillingproposallistdto"></a>
<a id="tocsc4wx1apifeaturesbillingproposaldtosgetactivebillingproposallistdto"></a>

```json
{}

```

### Properties

*None*

<h2 id="tocS_C4WX1APIFeaturesBillingProposalDtosGetAllBillingProposalListDto">C4WX1APIFeaturesBillingProposalDtosGetAllBillingProposalListDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesbillingproposaldtosgetallbillingproposallistdto"></a>
<a id="schema_C4WX1APIFeaturesBillingProposalDtosGetAllBillingProposalListDto"></a>
<a id="tocSc4wx1apifeaturesbillingproposaldtosgetallbillingproposallistdto"></a>
<a id="tocsc4wx1apifeaturesbillingproposaldtosgetallbillingproposallistdto"></a>

```json
{}

```

### Properties

*None*

<h2 id="tocS_C4WX1APIFeaturesBillingProposalDtosGetBillingProposalCountDto">C4WX1APIFeaturesBillingProposalDtosGetBillingProposalCountDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesbillingproposaldtosgetbillingproposalcountdto"></a>
<a id="schema_C4WX1APIFeaturesBillingProposalDtosGetBillingProposalCountDto"></a>
<a id="tocSc4wx1apifeaturesbillingproposaldtosgetbillingproposalcountdto"></a>
<a id="tocsc4wx1apifeaturesbillingproposaldtosgetbillingproposalcountdto"></a>

```json
{}

```

### Properties

*None*

<h2 id="tocS_C4WX1APIFeaturesBillingProposalDtosGetHistoryBillingProposalListDto">C4WX1APIFeaturesBillingProposalDtosGetHistoryBillingProposalListDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesbillingproposaldtosgethistorybillingproposallistdto"></a>
<a id="schema_C4WX1APIFeaturesBillingProposalDtosGetHistoryBillingProposalListDto"></a>
<a id="tocSc4wx1apifeaturesbillingproposaldtosgethistorybillingproposallistdto"></a>
<a id="tocsc4wx1apifeaturesbillingproposaldtosgethistorybillingproposallistdto"></a>

```json
{}

```

### Properties

*None*

<h2 id="tocS_C4WX1APIFeaturesBillingProposalDtosGetBillingProposalListDto">C4WX1APIFeaturesBillingProposalDtosGetBillingProposalListDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesbillingproposaldtosgetbillingproposallistdto"></a>
<a id="schema_C4WX1APIFeaturesBillingProposalDtosGetBillingProposalListDto"></a>
<a id="tocSc4wx1apifeaturesbillingproposaldtosgetbillingproposallistdto"></a>
<a id="tocsc4wx1apifeaturesbillingproposaldtosgetbillingproposallistdto"></a>

```json
{}

```

### Properties

allOf

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[C4WX1APIFeaturesSharedDtosGetListDto](#schemac4wx1apifeaturesshareddtosgetlistdto)|false|none|none|

and

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|object|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesBillingProposalDtosGetBillingProposalSessionBalanceDto">C4WX1APIFeaturesBillingProposalDtosGetBillingProposalSessionBalanceDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesbillingproposaldtosgetbillingproposalsessionbalancedto"></a>
<a id="schema_C4WX1APIFeaturesBillingProposalDtosGetBillingProposalSessionBalanceDto"></a>
<a id="tocSc4wx1apifeaturesbillingproposaldtosgetbillingproposalsessionbalancedto"></a>
<a id="tocsc4wx1apifeaturesbillingproposaldtosgetbillingproposalsessionbalancedto"></a>

```json
{}

```

### Properties

*None*

<h2 id="tocS_C4WX1APIFeaturesBillingProposalDtosDeleteBillingProposalDto">C4WX1APIFeaturesBillingProposalDtosDeleteBillingProposalDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesbillingproposaldtosdeletebillingproposaldto"></a>
<a id="schema_C4WX1APIFeaturesBillingProposalDtosDeleteBillingProposalDto"></a>
<a id="tocSc4wx1apifeaturesbillingproposaldtosdeletebillingproposaldto"></a>
<a id="tocsc4wx1apifeaturesbillingproposaldtosdeletebillingproposaldto"></a>

```json
{
  "UserId": 1
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|UserId|integer(int32)|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesBillingProposalDtosCreateBillingProposalDto">C4WX1APIFeaturesBillingProposalDtosCreateBillingProposalDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesbillingproposaldtoscreatebillingproposaldto"></a>
<a id="schema_C4WX1APIFeaturesBillingProposalDtosCreateBillingProposalDto"></a>
<a id="tocSc4wx1apifeaturesbillingproposaldtoscreatebillingproposaldto"></a>
<a id="tocsc4wx1apifeaturesbillingproposaldtoscreatebillingproposaldto"></a>

```json
{
  "PatientID_FK": 1,
  "Title": "Title",
  "SendEmail": true,
  "EmailPatient": true,
  "EmailTo": "test-to@gmail.com",
  "EmailCC": "test-cc@gmail.com",
  "EmailBCC": "test-bcc@gmail.com",
  "CurrencyID_FK": 1,
  "Status": "Active",
  "GroupNumber": "1",
  "Version": 1,
  "ProposalType": "ProposalType",
  "UserId": 1,
  "ServiceList": [
    {
      "BillingInvoiceServiceID": 0,
      "BillingProposalID_FK": 0,
      "ServiceID_FK": 1,
      "CategoryId": 0,
      "Title": null,
      "StartDate": "2025-02-27T23:51:34.5585733+08:00",
      "EndDate": "2025-02-27T23:51:34.558576+08:00",
      "UnitCost": 0,
      "Duration1": "Duration1",
      "Duration2": "Duration2",
      "Visit": 1,
      "Session": 0,
      "Discount": 0,
      "ServiceDescription": "ServiceDescription",
      "CategoryName": null
    }
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|PatientID_FK|integer(int32)|false|none|none|
|Title|string|false|none|none|
|SendEmail|boolean¦null|false|none|none|
|EmailPatient|boolean¦null|false|none|none|
|EmailTo|string¦null|false|none|none|
|EmailCC|string¦null|false|none|none|
|EmailBCC|string¦null|false|none|none|
|CurrencyID_FK|integer(int32)|false|none|none|
|Status|string|false|none|none|
|GroupNumber|string|false|none|none|
|Version|integer|false|none|none|
|ProposalType|string|false|none|none|
|UserId|integer(int32)|false|none|none|
|ServiceList|[[C4WX1APIFeaturesBillingProposalDtosBillingProposalServiceDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposalservicedto)]|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesAPIAccessKeyDtosAPIAccessKeyDto">C4WX1APIFeaturesAPIAccessKeyDtosAPIAccessKeyDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesapiaccesskeydtosapiaccesskeydto"></a>
<a id="schema_C4WX1APIFeaturesAPIAccessKeyDtosAPIAccessKeyDto"></a>
<a id="tocSc4wx1apifeaturesapiaccesskeydtosapiaccesskeydto"></a>
<a id="tocsc4wx1apifeaturesapiaccesskeydtosapiaccesskeydto"></a>

```json
{
  "APIAccessKeyID": 0,
  "TokenCode": "string",
  "AccessKey": "string",
  "ExpiryDate": "2019-08-24T14:15:22Z",
  "CreatedDate": "2019-08-24T14:15:22Z",
  "UpdatedDate": "2019-08-24T14:15:22Z",
  "UserId_FK": 0
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|APIAccessKeyID|integer(int32)|false|none|none|
|TokenCode|string|false|none|none|
|AccessKey|string|false|none|none|
|ExpiryDate|string(date-time)|false|none|none|
|CreatedDate|string(date-time)|false|none|none|
|UpdatedDate|string(date-time)¦null|false|none|none|
|UserId_FK|integer(int32)¦null|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesAPIAccessKeyDtosGetAPIAccessKeyDto">C4WX1APIFeaturesAPIAccessKeyDtosGetAPIAccessKeyDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesapiaccesskeydtosgetapiaccesskeydto"></a>
<a id="schema_C4WX1APIFeaturesAPIAccessKeyDtosGetAPIAccessKeyDto"></a>
<a id="tocSc4wx1apifeaturesapiaccesskeydtosgetapiaccesskeydto"></a>
<a id="tocsc4wx1apifeaturesapiaccesskeydtosgetapiaccesskeydto"></a>

```json
{}

```

### Properties

allOf

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[C4WX1APIFeaturesSharedDtosGetByIdDto](#schemac4wx1apifeaturesshareddtosgetbyiddto)|false|none|none|

and

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|object|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesAPIAccessKeyDtosCreateAPIAccessKeyDto">C4WX1APIFeaturesAPIAccessKeyDtosCreateAPIAccessKeyDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesapiaccesskeydtoscreateapiaccesskeydto"></a>
<a id="schema_C4WX1APIFeaturesAPIAccessKeyDtosCreateAPIAccessKeyDto"></a>
<a id="tocSc4wx1apifeaturesapiaccesskeydtoscreateapiaccesskeydto"></a>
<a id="tocsc4wx1apifeaturesapiaccesskeydtoscreateapiaccesskeydto"></a>

```json
{
  "Code": "string",
  "UserId": 0
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|Code|string|false|none|none|
|UserId|integer(int32)|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesActivityDtosUpdateActivityDto">C4WX1APIFeaturesActivityDtosUpdateActivityDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesactivitydtosupdateactivitydto"></a>
<a id="schema_C4WX1APIFeaturesActivityDtosUpdateActivityDto"></a>
<a id="tocSc4wx1apifeaturesactivitydtosupdateactivitydto"></a>
<a id="tocsc4wx1apifeaturesactivitydtosupdateactivitydto"></a>

```json
{
  "ProblemListID_FK": 1,
  "DiseaseID_FK": 1,
  "ActivityDetail": "Activity Detail",
  "DiseaseSubInfoID_FK": 1,
  "UserId": 1
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|ProblemListID_FK|integer(int32)|false|none|none|
|DiseaseID_FK|integer(int32)|false|none|none|
|ActivityDetail|string|false|none|none|
|DiseaseSubInfoID_FK|integer(int32)¦null|false|none|none|
|UserId|integer(int32)|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesActivityDtosActivityDto">C4WX1APIFeaturesActivityDtosActivityDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesactivitydtosactivitydto"></a>
<a id="schema_C4WX1APIFeaturesActivityDtosActivityDto"></a>
<a id="tocSc4wx1apifeaturesactivitydtosactivitydto"></a>
<a id="tocsc4wx1apifeaturesactivitydtosactivitydto"></a>

```json
{
  "ActivityID": 0,
  "ProblemListID_FK": 0,
  "DiseaseID_FK": 0,
  "ActivityDetail": "string",
  "IsDeleted": true,
  "CreatedDate": "2019-08-24T14:15:22Z",
  "CreatedBy_FK": 0,
  "ModifiedDate": "2019-08-24T14:15:22Z",
  "ModifiedBy_FK": 0,
  "DiseaseSubInfoID_FK": 0,
  "CanDelete": true
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|ActivityID|integer(int32)|false|none|none|
|ProblemListID_FK|integer(int32)|false|none|none|
|DiseaseID_FK|integer(int32)|false|none|none|
|ActivityDetail|string|false|none|none|
|IsDeleted|boolean|false|none|none|
|CreatedDate|string(date-time)¦null|false|none|none|
|CreatedBy_FK|integer(int32)¦null|false|none|none|
|ModifiedDate|string(date-time)¦null|false|none|none|
|ModifiedBy_FK|integer(int32)¦null|false|none|none|
|DiseaseSubInfoID_FK|integer(int32)¦null|false|none|none|
|CanDelete|boolean|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesActivityDtosCreateActivityDto">C4WX1APIFeaturesActivityDtosCreateActivityDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesactivitydtoscreateactivitydto"></a>
<a id="schema_C4WX1APIFeaturesActivityDtosCreateActivityDto"></a>
<a id="tocSc4wx1apifeaturesactivitydtoscreateactivitydto"></a>
<a id="tocsc4wx1apifeaturesactivitydtoscreateactivitydto"></a>

```json
{
  "ProblemListID_FK": 1,
  "DiseaseID_FK": 1,
  "ActivityDetail": "Activity Detail",
  "DiseaseSubInfoID_FK": 1,
  "UserId": 1
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|ProblemListID_FK|integer(int32)|false|none|none|
|DiseaseID_FK|integer(int32)|false|none|none|
|ActivityDetail|string|false|none|none|
|DiseaseSubInfoID_FK|integer(int32)¦null|false|none|none|
|UserId|integer(int32)|false|none|none|

