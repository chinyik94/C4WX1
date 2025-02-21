---
title: C4WX1.API v1.0.0
language_tabs:
  - shell: curl
  - http: HTTP
  - javascript: JavaScript
  - python: Python
language_clients:
  - shell: ""
  - http: ""
  - javascript: ""
  - python: ""
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

## Update SysConfig

<a id="opIdC4WX1APIFeaturesSysConfigUpdateUpdate"></a>

> Code samples

```shell
# You can also use wget
curl -X PUT https://localhost:7055/api/sysconfig \
  -H 'Content-Type: */*' \
  -H 'Accept: application/problem+json'

```

```http
PUT https://localhost:7055/api/sysconfig HTTP/1.1
Host: localhost:7055
Content-Type: */*
Accept: application/problem+json

```

```javascript
const inputBody = '[
  {
    "configName": "Config1",
    "configValue": "Value1",
    "userID": 1
  },
  {
    "configName": "Config2",
    "configValue": "Value2",
    "userID": 1
  }
]';
const headers = {
  'Content-Type':'*/*',
  'Accept':'application/problem+json'
};

fetch('https://localhost:7055/api/sysconfig',
{
  method: 'PUT',
  body: inputBody,
  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```python
import requests
headers = {
  'Content-Type': '*/*',
  'Accept': 'application/problem+json'
}

r = requests.put('https://localhost:7055/api/sysconfig', headers = headers)

print(r.json())

```

`PUT /api/sysconfig`

Update one or multiple existing SysConfigs

> Body parameter

<h3 id="update-sysconfig-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[C4WX1APIFeaturesSysConfigDtosUpdateSysConfigDto](#schemac4wx1apifeaturessysconfigdtosupdatesysconfigdto)|true|none|

> Example responses

> 500 Response

```json
{
  "status": "Internal Server Error!",
  "code": 500,
  "reason": "Something unexpected has happened",
  "note": "See application log for stack trace."
}
```

<h3 id="update-sysconfig-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|204|[No Content](https://tools.ietf.org/html/rfc7231#section-6.3.5)|SysConfig updated successfully|None|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|SysConfig not found|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## Get SysConfig List

<a id="opIdC4WX1APIFeaturesSysConfigGetGetList"></a>

> Code samples

```shell
# You can also use wget
curl -X GET https://localhost:7055/api/sysconfig \
  -H 'Accept: application/json'

```

```http
GET https://localhost:7055/api/sysconfig HTTP/1.1
Host: localhost:7055
Accept: application/json

```

```javascript

const headers = {
  'Accept':'application/json'
};

fetch('https://localhost:7055/api/sysconfig',
{
  method: 'GET',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```python
import requests
headers = {
  'Accept': 'application/json'
}

r = requests.get('https://localhost:7055/api/sysconfig', headers = headers)

print(r.json())

```

`GET /api/sysconfig`

Get a filtered, paged and sorted list of SysConfigs

<h3 id="get-sysconfig-list-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|configName|query|string|false|none|
|configValue|query|string|false|none|
|pageIndex|query|integer(int32)|false|none|
|pageSize|query|integer(int32)|false|none|
|orderBy|query|string|false|none|

> Example responses

> 200 Response

```json
[
  {
    "configName": "string",
    "configValue": "string",
    "modifiedDate": "2019-08-24T14:15:22Z",
    "modifiedBy_FK": 0,
    "isConfigurable": true,
    "description": "string"
  }
]
```

<h3 id="get-sysconfig-list-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|SysConfig List retrieved successfully|Inline|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<h3 id="get-sysconfig-list-responseschema">Response Schema</h3>

Status Code **200**

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[[C4WX1APIFeaturesSysConfigDtosSysConfigDto](#schemac4wx1apifeaturessysconfigdtossysconfigdto)]|false|none|none|
|» configName|string|false|none|none|
|» configValue|string¦null|false|none|none|
|» modifiedDate|string(date-time)¦null|false|none|none|
|» modifiedBy_FK|integer(int32)¦null|false|none|none|
|» isConfigurable|boolean¦null|false|none|none|
|» description|string¦null|false|none|none|

<aside class="success">
This operation does not require authentication
</aside>

## Create SysConfig

<a id="opIdC4WX1APIFeaturesSysConfigCreateCreate"></a>

> Code samples

```shell
# You can also use wget
curl -X POST https://localhost:7055/api/sysconfig \
  -H 'Content-Type: */*' \
  -H 'Accept: application/problem+json'

```

```http
POST https://localhost:7055/api/sysconfig HTTP/1.1
Host: localhost:7055
Content-Type: */*
Accept: application/problem+json

```

```javascript
const inputBody = '{
  "configName": "Config Name",
  "configValue": "Config Value",
  "isConfigurable": false,
  "description": "Description"
}';
const headers = {
  'Content-Type':'*/*',
  'Accept':'application/problem+json'
};

fetch('https://localhost:7055/api/sysconfig',
{
  method: 'POST',
  body: inputBody,
  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```python
import requests
headers = {
  'Content-Type': '*/*',
  'Accept': 'application/problem+json'
}

r = requests.post('https://localhost:7055/api/sysconfig', headers = headers)

print(r.json())

```

`POST /api/sysconfig`

Create a new SysConfig

> Body parameter

<h3 id="create-sysconfig-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[C4WX1APIFeaturesSysConfigDtosCreateSysConfigDto](#schemac4wx1apifeaturessysconfigdtoscreatesysconfigdto)|true|none|

> Example responses

> 500 Response

```json
{
  "status": "Internal Server Error!",
  "code": 500,
  "reason": "Something unexpected has happened",
  "note": "See application log for stack trace."
}
```

<h3 id="create-sysconfig-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|204|[No Content](https://tools.ietf.org/html/rfc7231#section-6.3.5)|SysConfig created successfully|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## Get SysConfig

<a id="opIdC4WX1APIFeaturesSysConfigGetGet"></a>

> Code samples

```shell
# You can also use wget
curl -X GET https://localhost:7055/api/sysconfig/config-name/{configName}?configName=string \
  -H 'Accept: application/json'

```

```http
GET https://localhost:7055/api/sysconfig/config-name/{configName}?configName=string HTTP/1.1
Host: localhost:7055
Accept: application/json

```

```javascript

const headers = {
  'Accept':'application/json'
};

fetch('https://localhost:7055/api/sysconfig/config-name/{configName}?configName=string',
{
  method: 'GET',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```python
import requests
headers = {
  'Accept': 'application/json'
}

r = requests.get('https://localhost:7055/api/sysconfig/config-name/{configName}', params={
  'configName': 'string'
}, headers = headers)

print(r.json())

```

`GET /api/sysconfig/config-name/{configName}`

Get SysConfig by its ConfigName

<h3 id="get-sysconfig-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|configName|path|string|true|none|
|configName|query|string|true|none|

> Example responses

> 200 Response

```json
{
  "configName": "string",
  "configValue": "string",
  "modifiedDate": "2019-08-24T14:15:22Z",
  "modifiedBy_FK": 0,
  "isConfigurable": true,
  "description": "string"
}
```

<h3 id="get-sysconfig-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|SysConfig retrieved successfully|[C4WX1APIFeaturesSysConfigDtosSysConfigDto](#schemac4wx1apifeaturessysconfigdtossysconfigdto)|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|SysConfig not found|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## Get All SysConfig

<a id="opIdC4WX1APIFeaturesSysConfigGetGetAllList"></a>

> Code samples

```shell
# You can also use wget
curl -X GET https://localhost:7055/api/sysconfig/all \
  -H 'Accept: application/json'

```

```http
GET https://localhost:7055/api/sysconfig/all HTTP/1.1
Host: localhost:7055
Accept: application/json

```

```javascript

const headers = {
  'Accept':'application/json'
};

fetch('https://localhost:7055/api/sysconfig/all',
{
  method: 'GET',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```python
import requests
headers = {
  'Accept': 'application/json'
}

r = requests.get('https://localhost:7055/api/sysconfig/all', headers = headers)

print(r.json())

```

`GET /api/sysconfig/all`

Get all SysConfigs

> Example responses

> 200 Response

```json
[
  {
    "configName": "string",
    "configValue": "string",
    "modifiedDate": "2019-08-24T14:15:22Z",
    "modifiedBy_FK": 0,
    "isConfigurable": true,
    "description": "string"
  }
]
```

<h3 id="get-all-sysconfig-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|SysConfig List retrieved successfully|Inline|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<h3 id="get-all-sysconfig-responseschema">Response Schema</h3>

Status Code **200**

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[[C4WX1APIFeaturesSysConfigDtosSysConfigDto](#schemac4wx1apifeaturessysconfigdtossysconfigdto)]|false|none|none|
|» configName|string|false|none|none|
|» configValue|string¦null|false|none|none|
|» modifiedDate|string(date-time)¦null|false|none|none|
|» modifiedBy_FK|integer(int32)¦null|false|none|none|
|» isConfigurable|boolean¦null|false|none|none|
|» description|string¦null|false|none|none|

<aside class="success">
This operation does not require authentication
</aside>

## Get SysConfig Count

<a id="opIdC4WX1APIFeaturesSysConfigGetGetCount"></a>

> Code samples

```shell
# You can also use wget
curl -X GET https://localhost:7055/api/sysconfig/count \
  -H 'Accept: application/json'

```

```http
GET https://localhost:7055/api/sysconfig/count HTTP/1.1
Host: localhost:7055
Accept: application/json

```

```javascript

const headers = {
  'Accept':'application/json'
};

fetch('https://localhost:7055/api/sysconfig/count',
{
  method: 'GET',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```python
import requests
headers = {
  'Accept': 'application/json'
}

r = requests.get('https://localhost:7055/api/sysconfig/count', headers = headers)

print(r.json())

```

`GET /api/sysconfig/count`

Get the number of SysConfigs

> Example responses

> 200 Response

```json
0
```

<h3 id="get-sysconfig-count-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Number of SysConfigs retrieved successfully|integer|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

<h1 id="c4wx1-api-chat">Chat</h1>

## Get Chat

<a id="opIdC4WX1APIFeaturesChatGetGetById"></a>

> Code samples

```shell
# You can also use wget
curl -X GET https://localhost:7055/api/chat/{id} \
  -H 'Accept: application/json'

```

```http
GET https://localhost:7055/api/chat/{id} HTTP/1.1
Host: localhost:7055
Accept: application/json

```

```javascript

const headers = {
  'Accept':'application/json'
};

fetch('https://localhost:7055/api/chat/{id}',
{
  method: 'GET',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```python
import requests
headers = {
  'Accept': 'application/json'
}

r = requests.get('https://localhost:7055/api/chat/{id}', headers = headers)

print(r.json())

```

`GET /api/chat/{id}`

Get Chat by its ID

<h3 id="get-chat-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|integer(int32)|true|none|

> Example responses

> 200 Response

```json
{
  "chatID": 0,
  "comment": "string",
  "attachment": "string",
  "attachment_Physical": "string",
  "parentID_FK": 0,
  "patientID_FK": 0,
  "createdDate": "2019-08-24T14:15:22Z",
  "createdBy_FK": 0,
  "isDeleted": true,
  "family": true,
  "userData": {
    "userId": 0,
    "firstname": "string",
    "lastname": "string",
    "photo": "string"
  },
  "patientData": {
    "patientID": 0,
    "firstname": "string",
    "lastname": "string",
    "photo": "string"
  },
  "commentList": [
    {
      "chatID": 0,
      "comment": "string",
      "attachment": "string",
      "attachment_Physical": "string",
      "parentID_FK": 0,
      "patientID_FK": 0,
      "createdDate": "2019-08-24T14:15:22Z",
      "createdBy_FK": 0,
      "isDeleted": true,
      "family": true,
      "userData": {
        "userId": 0,
        "firstname": "string",
        "lastname": "string",
        "photo": "string"
      },
      "patientData": {
        "patientID": 0,
        "firstname": "string",
        "lastname": "string",
        "photo": "string"
      },
      "commentList": []
    }
  ]
}
```

<h3 id="get-chat-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Chat retrieved successfully|[C4WX1APIFeaturesChatDtosChatDto](#schemac4wx1apifeatureschatdtoschatdto)|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## Get Can Load More Chat

<a id="opIdC4WX1APIFeaturesChatGetGetCanLoadMore"></a>

> Code samples

```shell
# You can also use wget
curl -X GET https://localhost:7055/api/chat/can-load-more \
  -H 'Accept: application/json'

```

```http
GET https://localhost:7055/api/chat/can-load-more HTTP/1.1
Host: localhost:7055
Accept: application/json

```

```javascript

const headers = {
  'Accept':'application/json'
};

fetch('https://localhost:7055/api/chat/can-load-more',
{
  method: 'GET',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```python
import requests
headers = {
  'Accept': 'application/json'
}

r = requests.get('https://localhost:7055/api/chat/can-load-more', headers = headers)

print(r.json())

```

`GET /api/chat/can-load-more`

Check if there are more chats to load

<h3 id="get-can-load-more-chat-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|min|query|integer(int32)|false|none|
|patientId|query|integer(int32)|false|none|
|userId|query|integer(int32)|false|none|

> Example responses

> 200 Response

```json
true
```

<h3 id="get-can-load-more-chat-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|boolean|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## Get Latest Chat List

<a id="opIdC4WX1APIFeaturesChatGetGetLatestList"></a>

> Code samples

```shell
# You can also use wget
curl -X GET https://localhost:7055/api/chat/latest?count=0 \
  -H 'Accept: application/json'

```

```http
GET https://localhost:7055/api/chat/latest?count=0 HTTP/1.1
Host: localhost:7055
Accept: application/json

```

```javascript

const headers = {
  'Accept':'application/json'
};

fetch('https://localhost:7055/api/chat/latest?count=0',
{
  method: 'GET',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```python
import requests
headers = {
  'Accept': 'application/json'
}

r = requests.get('https://localhost:7055/api/chat/latest', params={
  'count': '0'
}, headers = headers)

print(r.json())

```

`GET /api/chat/latest`

Get the latest Chat list

<h3 id="get-latest-chat-list-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|chatID|query|integer(int32)|false|none|
|patientID|query|integer(int32)|false|none|
|userID|query|integer(int32)|false|none|
|count|query|integer(int32)|true|none|
|family|query|boolean|false|none|

> Example responses

> 200 Response

```json
[
  {
    "chatID": 0,
    "comment": "string",
    "attachment": "string",
    "attachment_Physical": "string",
    "parentID_FK": 0,
    "patientID_FK": 0,
    "createdDate": "2019-08-24T14:15:22Z",
    "createdBy_FK": 0,
    "isDeleted": true,
    "family": true,
    "userData": {
      "userId": 0,
      "firstname": "string",
      "lastname": "string",
      "photo": "string"
    },
    "patientData": {
      "patientID": 0,
      "firstname": "string",
      "lastname": "string",
      "photo": "string"
    },
    "commentList": [
      {}
    ]
  }
]
```

<h3 id="get-latest-chat-list-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Chat list retrieved successfully|Inline|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<h3 id="get-latest-chat-list-responseschema">Response Schema</h3>

Status Code **200**

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[[C4WX1APIFeaturesChatDtosChatDto](#schemac4wx1apifeatureschatdtoschatdto)]|false|none|none|
|» chatID|integer(int32)|false|none|none|
|» comment|string¦null|false|none|none|
|» attachment|string¦null|false|none|none|
|» attachment_Physical|string¦null|false|none|none|
|» parentID_FK|integer(int32)¦null|false|none|none|
|» patientID_FK|integer(int32)¦null|false|none|none|
|» createdDate|string(date-time)|false|none|none|
|» createdBy_FK|integer(int32)|false|none|none|
|» isDeleted|boolean|false|none|none|
|» family|boolean¦null|false|none|none|
|» userData|[C4WX1APIFeaturesChatDtosChatUserDto](#schemac4wx1apifeatureschatdtoschatuserdto)¦null|false|none|none|
|»» userId|integer(int32)|false|none|none|
|»» firstname|string|false|none|none|
|»» lastname|string|false|none|none|
|»» photo|string¦null|false|none|none|
|» patientData|[C4WX1APIFeaturesChatDtosChatPatientDto](#schemac4wx1apifeatureschatdtoschatpatientdto)¦null|false|none|none|
|»» patientID|integer(int32)|false|none|none|
|»» firstname|string|false|none|none|
|»» lastname|string|false|none|none|
|»» photo|string¦null|false|none|none|
|» commentList|[[C4WX1APIFeaturesChatDtosChatDto](#schemac4wx1apifeatureschatdtoschatdto)]|false|none|none|

<aside class="success">
This operation does not require authentication
</aside>

## Get Previous Chat List

<a id="opIdC4WX1APIFeaturesChatGetGetPreviousList"></a>

> Code samples

```shell
# You can also use wget
curl -X GET https://localhost:7055/api/chat/previous?count=0 \
  -H 'Accept: application/json'

```

```http
GET https://localhost:7055/api/chat/previous?count=0 HTTP/1.1
Host: localhost:7055
Accept: application/json

```

```javascript

const headers = {
  'Accept':'application/json'
};

fetch('https://localhost:7055/api/chat/previous?count=0',
{
  method: 'GET',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```python
import requests
headers = {
  'Accept': 'application/json'
}

r = requests.get('https://localhost:7055/api/chat/previous', params={
  'count': '0'
}, headers = headers)

print(r.json())

```

`GET /api/chat/previous`

Get the previous Chat list

<h3 id="get-previous-chat-list-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|chatID|query|integer(int32)|false|none|
|patientID|query|integer(int32)|false|none|
|userID|query|integer(int32)|false|none|
|count|query|integer(int32)|true|none|
|family|query|boolean|false|none|

> Example responses

> 200 Response

```json
[
  {
    "chatID": 0,
    "comment": "string",
    "attachment": "string",
    "attachment_Physical": "string",
    "parentID_FK": 0,
    "patientID_FK": 0,
    "createdDate": "2019-08-24T14:15:22Z",
    "createdBy_FK": 0,
    "isDeleted": true,
    "family": true,
    "userData": {
      "userId": 0,
      "firstname": "string",
      "lastname": "string",
      "photo": "string"
    },
    "patientData": {
      "patientID": 0,
      "firstname": "string",
      "lastname": "string",
      "photo": "string"
    },
    "commentList": [
      {}
    ]
  }
]
```

<h3 id="get-previous-chat-list-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Chat list retrieved successfully|Inline|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<h3 id="get-previous-chat-list-responseschema">Response Schema</h3>

Status Code **200**

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[[C4WX1APIFeaturesChatDtosChatDto](#schemac4wx1apifeatureschatdtoschatdto)]|false|none|none|
|» chatID|integer(int32)|false|none|none|
|» comment|string¦null|false|none|none|
|» attachment|string¦null|false|none|none|
|» attachment_Physical|string¦null|false|none|none|
|» parentID_FK|integer(int32)¦null|false|none|none|
|» patientID_FK|integer(int32)¦null|false|none|none|
|» createdDate|string(date-time)|false|none|none|
|» createdBy_FK|integer(int32)|false|none|none|
|» isDeleted|boolean|false|none|none|
|» family|boolean¦null|false|none|none|
|» userData|[C4WX1APIFeaturesChatDtosChatUserDto](#schemac4wx1apifeatureschatdtoschatuserdto)¦null|false|none|none|
|»» userId|integer(int32)|false|none|none|
|»» firstname|string|false|none|none|
|»» lastname|string|false|none|none|
|»» photo|string¦null|false|none|none|
|» patientData|[C4WX1APIFeaturesChatDtosChatPatientDto](#schemac4wx1apifeatureschatdtoschatpatientdto)¦null|false|none|none|
|»» patientID|integer(int32)|false|none|none|
|»» firstname|string|false|none|none|
|»» lastname|string|false|none|none|
|»» photo|string¦null|false|none|none|
|» commentList|[[C4WX1APIFeaturesChatDtosChatDto](#schemac4wx1apifeatureschatdtoschatdto)]|false|none|none|

<aside class="success">
This operation does not require authentication
</aside>

## Delete Chat

<a id="opIdC4WX1APIFeaturesChatDeleteDelete"></a>

> Code samples

```shell
# You can also use wget
curl -X DELETE https://localhost:7055/api/chat/{chatID} \
  -H 'Content-Type: */*' \
  -H 'Accept: application/problem+json'

```

```http
DELETE https://localhost:7055/api/chat/{chatID} HTTP/1.1
Host: localhost:7055
Content-Type: */*
Accept: application/problem+json

```

```javascript
const inputBody = '{
  "userID": 1
}';
const headers = {
  'Content-Type':'*/*',
  'Accept':'application/problem+json'
};

fetch('https://localhost:7055/api/chat/{chatID}',
{
  method: 'DELETE',
  body: inputBody,
  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```python
import requests
headers = {
  'Content-Type': '*/*',
  'Accept': 'application/problem+json'
}

r = requests.delete('https://localhost:7055/api/chat/{chatID}', headers = headers)

print(r.json())

```

`DELETE /api/chat/{chatID}`

Delete an existing Chat

> Body parameter

<h3 id="delete-chat-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|chatID|path|integer(int32)|true|none|
|body|body|[C4WX1APIFeaturesChatDtosDeleteChatDto](#schemac4wx1apifeatureschatdtosdeletechatdto)|true|none|

> Example responses

> 500 Response

```json
{
  "status": "Internal Server Error!",
  "code": 500,
  "reason": "Something unexpected has happened",
  "note": "See application log for stack trace."
}
```

<h3 id="delete-chat-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|204|[No Content](https://tools.ietf.org/html/rfc7231#section-6.3.5)|Chat deleted successfully|None|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Chat not found|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## Create Chat

<a id="opIdC4WX1APIFeaturesChatCreateCreate"></a>

> Code samples

```shell
# You can also use wget
curl -X POST https://localhost:7055/api/chat \
  -H 'Content-Type: */*' \
  -H 'Accept: application/json'

```

```http
POST https://localhost:7055/api/chat HTTP/1.1
Host: localhost:7055
Content-Type: */*
Accept: application/json

```

```javascript
const inputBody = '{
  "attachment": "Attachment",
  "attachment_Physical": "Attachment_Physical",
  "createdBy_FK": 1,
  "parentID_FK": 1,
  "patientID_FK": 1,
  "comment": "Comment",
  "family": true
}';
const headers = {
  'Content-Type':'*/*',
  'Accept':'application/json'
};

fetch('https://localhost:7055/api/chat',
{
  method: 'POST',
  body: inputBody,
  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```python
import requests
headers = {
  'Content-Type': '*/*',
  'Accept': 'application/json'
}

r = requests.post('https://localhost:7055/api/chat', headers = headers)

print(r.json())

```

`POST /api/chat`

Create a new Chat

> Body parameter

<h3 id="create-chat-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[C4WX1APIFeaturesChatDtosCreateChatDto](#schemac4wx1apifeatureschatdtoscreatechatdto)|true|none|

> Example responses

> 200 Response

```json
{
  "chatID": 0,
  "comment": "string",
  "attachment": "string",
  "attachment_Physical": "string",
  "parentID_FK": 0,
  "patientID_FK": 0,
  "createdDate": "2019-08-24T14:15:22Z",
  "createdBy_FK": 0,
  "isDeleted": true,
  "family": true,
  "userData": {
    "userId": 0,
    "firstname": "string",
    "lastname": "string",
    "photo": "string"
  },
  "patientData": {
    "patientID": 0,
    "firstname": "string",
    "lastname": "string",
    "photo": "string"
  },
  "commentList": [
    {
      "chatID": 0,
      "comment": "string",
      "attachment": "string",
      "attachment_Physical": "string",
      "parentID_FK": 0,
      "patientID_FK": 0,
      "createdDate": "2019-08-24T14:15:22Z",
      "createdBy_FK": 0,
      "isDeleted": true,
      "family": true,
      "userData": {
        "userId": 0,
        "firstname": "string",
        "lastname": "string",
        "photo": "string"
      },
      "patientData": {
        "patientID": 0,
        "firstname": "string",
        "lastname": "string",
        "photo": "string"
      },
      "commentList": []
    }
  ]
}
```

<h3 id="create-chat-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Chat created successfully|[C4WX1APIFeaturesChatDtosChatDto](#schemac4wx1apifeatureschatdtoschatdto)|
|400|[Bad Request](https://tools.ietf.org/html/rfc7231#section-6.5.1)|Invalid request|[FastEndpointsErrorResponse](#schemafastendpointserrorresponse)|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

<h1 id="c4wx1-api-c4w-image">C4w-Image</h1>

## Update C4W Image

<a id="opIdC4WX1APIFeaturesC4WImageUpdateUpdate"></a>

> Code samples

```shell
# You can also use wget
curl -X PUT https://localhost:7055/api/c4w-image/{c4wImageId} \
  -H 'Content-Type: */*' \
  -H 'Accept: application/problem+json'

```

```http
PUT https://localhost:7055/api/c4w-image/{c4wImageId} HTTP/1.1
Host: localhost:7055
Content-Type: */*
Accept: application/problem+json

```

```javascript
const inputBody = '{
  "woundImageName": "wound image name",
  "woundImageData": "wound image data",
  "woundBedImageName": "wound bed image name",
  "woundBedImageData": "wound bed image data",
  "tissueImageName": "tissue image name",
  "tissueImageData": "tissue image data",
  "depthImageName": "depth image name",
  "depthImageData": "depth image data",
  "userId": 1
}';
const headers = {
  'Content-Type':'*/*',
  'Accept':'application/problem+json'
};

fetch('https://localhost:7055/api/c4w-image/{c4wImageId}',
{
  method: 'PUT',
  body: inputBody,
  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```python
import requests
headers = {
  'Content-Type': '*/*',
  'Accept': 'application/problem+json'
}

r = requests.put('https://localhost:7055/api/c4w-image/{c4wImageId}', headers = headers)

print(r.json())

```

`PUT /api/c4w-image/{c4wImageId}`

Update an existing C4W Image

> Body parameter

<h3 id="update-c4w-image-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|c4wImageId|path|integer(int32)|true|none|
|body|body|[C4WX1APIFeaturesC4WImageDtosUpdateC4WImageDto](#schemac4wx1apifeaturesc4wimagedtosupdatec4wimagedto)|true|none|

> Example responses

> 500 Response

```json
{
  "status": "Internal Server Error!",
  "code": 500,
  "reason": "Something unexpected has happened",
  "note": "See application log for stack trace."
}
```

<h3 id="update-c4w-image-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|204|[No Content](https://tools.ietf.org/html/rfc7231#section-6.3.5)|C4W Image updated successfully|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## Get C4W Image

<a id="opIdC4WX1APIFeaturesC4WImageGetGetById"></a>

> Code samples

```shell
# You can also use wget
curl -X GET https://localhost:7055/api/c4w-image/{id} \
  -H 'Accept: application/json'

```

```http
GET https://localhost:7055/api/c4w-image/{id} HTTP/1.1
Host: localhost:7055
Accept: application/json

```

```javascript

const headers = {
  'Accept':'application/json'
};

fetch('https://localhost:7055/api/c4w-image/{id}',
{
  method: 'GET',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```python
import requests
headers = {
  'Accept': 'application/json'
}

r = requests.get('https://localhost:7055/api/c4w-image/{id}', headers = headers)

print(r.json())

```

`GET /api/c4w-image/{id}`

Get a C4W Image by its ID

<h3 id="get-c4w-image-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|integer(int32)|true|none|

> Example responses

> 200 Response

```json
{
  "c4WImageId": 0,
  "woundImageName": "string",
  "woundImageData": "string",
  "woundBedImageName": "string",
  "woundBedImageData": "string",
  "tissueImageName": "string",
  "tissueImageData": "string",
  "depthImageName": "string",
  "depthImageData": "string",
  "isDeleted": true,
  "createdDate": "2019-08-24T14:15:22Z",
  "createdBy_FK": 0,
  "modifiedDate": "2019-08-24T14:15:22Z"
}
```

<h3 id="get-c4w-image-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|C4W Image retrieved successfully|[C4WX1APIFeaturesC4WImageDtosC4WImageDto](#schemac4wx1apifeaturesc4wimagedtosc4wimagedto)|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## Get C4W Image Count

<a id="opIdC4WX1APIFeaturesC4WImageGetGetCount"></a>

> Code samples

```shell
# You can also use wget
curl -X GET https://localhost:7055/api/c4w-image/count?fromDate=2019-08-24T14%3A15%3A22Z&toDate=2019-08-24T14%3A15%3A22Z \
  -H 'Accept: application/json'

```

```http
GET https://localhost:7055/api/c4w-image/count?fromDate=2019-08-24T14%3A15%3A22Z&toDate=2019-08-24T14%3A15%3A22Z HTTP/1.1
Host: localhost:7055
Accept: application/json

```

```javascript

const headers = {
  'Accept':'application/json'
};

fetch('https://localhost:7055/api/c4w-image/count?fromDate=2019-08-24T14%3A15%3A22Z&toDate=2019-08-24T14%3A15%3A22Z',
{
  method: 'GET',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```python
import requests
headers = {
  'Accept': 'application/json'
}

r = requests.get('https://localhost:7055/api/c4w-image/count', params={
  'fromDate': '2019-08-24T14:15:22Z',  'toDate': '2019-08-24T14:15:22Z'
}, headers = headers)

print(r.json())

```

`GET /api/c4w-image/count`

Get C4W Image Count based on its CreatedDate

<h3 id="get-c4w-image-count-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|fromDate|query|string(date-time)|true|none|
|toDate|query|string(date-time)|true|none|

> Example responses

> 200 Response

```json
0
```

<h3 id="get-c4w-image-count-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|C4W Image Count retrieved successfully|integer|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## Get C4W Image List

<a id="opIdC4WX1APIFeaturesC4WImageGetGetList"></a>

> Code samples

```shell
# You can also use wget
curl -X GET https://localhost:7055/api/c4w-image?fromDate=2019-08-24T14%3A15%3A22Z&toDate=2019-08-24T14%3A15%3A22Z \
  -H 'Accept: application/json'

```

```http
GET https://localhost:7055/api/c4w-image?fromDate=2019-08-24T14%3A15%3A22Z&toDate=2019-08-24T14%3A15%3A22Z HTTP/1.1
Host: localhost:7055
Accept: application/json

```

```javascript

const headers = {
  'Accept':'application/json'
};

fetch('https://localhost:7055/api/c4w-image?fromDate=2019-08-24T14%3A15%3A22Z&toDate=2019-08-24T14%3A15%3A22Z',
{
  method: 'GET',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```python
import requests
headers = {
  'Accept': 'application/json'
}

r = requests.get('https://localhost:7055/api/c4w-image', params={
  'fromDate': '2019-08-24T14:15:22Z',  'toDate': '2019-08-24T14:15:22Z'
}, headers = headers)

print(r.json())

```

`GET /api/c4w-image`

Get a filtered, paged and sorted C4W Image List

<h3 id="get-c4w-image-list-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|fromDate|query|string(date-time)|true|none|
|toDate|query|string(date-time)|true|none|
|pageIndex|query|integer(int32)|false|none|
|pageSize|query|integer(int32)|false|none|
|orderBy|query|string|false|none|

> Example responses

> 200 Response

```json
[
  {
    "c4WImageId": 0,
    "woundImageName": "string",
    "woundImageData": "string",
    "woundBedImageName": "string",
    "woundBedImageData": "string",
    "tissueImageName": "string",
    "tissueImageData": "string",
    "depthImageName": "string",
    "depthImageData": "string",
    "isDeleted": true,
    "createdDate": "2019-08-24T14:15:22Z",
    "createdBy_FK": 0,
    "modifiedDate": "2019-08-24T14:15:22Z"
  }
]
```

<h3 id="get-c4w-image-list-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|C4W Image List retrieved successfully|Inline|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<h3 id="get-c4w-image-list-responseschema">Response Schema</h3>

Status Code **200**

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[[C4WX1APIFeaturesC4WImageDtosC4WImageDto](#schemac4wx1apifeaturesc4wimagedtosc4wimagedto)]|false|none|none|
|» c4WImageId|integer(int32)|false|none|none|
|» woundImageName|string¦null|false|none|none|
|» woundImageData|string¦null|false|none|none|
|» woundBedImageName|string¦null|false|none|none|
|» woundBedImageData|string¦null|false|none|none|
|» tissueImageName|string¦null|false|none|none|
|» tissueImageData|string¦null|false|none|none|
|» depthImageName|string¦null|false|none|none|
|» depthImageData|string¦null|false|none|none|
|» isDeleted|boolean|false|none|none|
|» createdDate|string(date-time)|false|none|none|
|» createdBy_FK|integer(int32)|false|none|none|
|» modifiedDate|string(date-time)¦null|false|none|none|

<aside class="success">
This operation does not require authentication
</aside>

## Create C4W Image

<a id="opIdC4WX1APIFeaturesC4WImageCreateCreate"></a>

> Code samples

```shell
# You can also use wget
curl -X POST https://localhost:7055/api/c4w-image \
  -H 'Content-Type: */*' \
  -H 'Accept: application/problem+json'

```

```http
POST https://localhost:7055/api/c4w-image HTTP/1.1
Host: localhost:7055
Content-Type: */*
Accept: application/problem+json

```

```javascript
const inputBody = '{
  "woundImageName": "wound image name",
  "woundImageData": "wound image data",
  "woundBedImageName": "wound bed image name",
  "woundBedImageData": "wound bed image data",
  "tissueImageName": "tissue image name",
  "tissueImageData": "tissue image data",
  "depthImageName": "depth image name",
  "depthImageData": "depth image data",
  "userId": 1
}';
const headers = {
  'Content-Type':'*/*',
  'Accept':'application/problem+json'
};

fetch('https://localhost:7055/api/c4w-image',
{
  method: 'POST',
  body: inputBody,
  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```python
import requests
headers = {
  'Content-Type': '*/*',
  'Accept': 'application/problem+json'
}

r = requests.post('https://localhost:7055/api/c4w-image', headers = headers)

print(r.json())

```

`POST /api/c4w-image`

Create a new C4W Image

> Body parameter

<h3 id="create-c4w-image-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[C4WX1APIFeaturesC4WImageDtosCreateC4WImageDto](#schemac4wx1apifeaturesc4wimagedtoscreatec4wimagedto)|true|none|

> Example responses

> 500 Response

```json
{
  "status": "Internal Server Error!",
  "code": 500,
  "reason": "Something unexpected has happened",
  "note": "See application log for stack trace."
}
```

<h3 id="create-c4w-image-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|204|[No Content](https://tools.ietf.org/html/rfc7231#section-6.3.5)|C4W Image created successfully|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

<h1 id="c4wx1-api-c4w-device-token">C4w-Device-Token</h1>

## Update C4W Device Token

<a id="opIdC4WX1APIFeaturesC4WDeviceTokenUpdateUpdate"></a>

> Code samples

```shell
# You can also use wget
curl -X PUT https://localhost:7055/api/c4w-device-token/{c4WDeviceTokenId} \
  -H 'Content-Type: */*' \
  -H 'Accept: application/problem+json'

```

```http
PUT https://localhost:7055/api/c4w-device-token/{c4WDeviceTokenId} HTTP/1.1
Host: localhost:7055
Content-Type: */*
Accept: application/problem+json

```

```javascript
const inputBody = '{
  "oldDeviceToken": "Old token",
  "newDeviceToken": "New token",
  "clientEnvironment": "test env",
  "device": "IPhone",
  "userId": 1
}';
const headers = {
  'Content-Type':'*/*',
  'Accept':'application/problem+json'
};

fetch('https://localhost:7055/api/c4w-device-token/{c4WDeviceTokenId}',
{
  method: 'PUT',
  body: inputBody,
  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```python
import requests
headers = {
  'Content-Type': '*/*',
  'Accept': 'application/problem+json'
}

r = requests.put('https://localhost:7055/api/c4w-device-token/{c4WDeviceTokenId}', headers = headers)

print(r.json())

```

`PUT /api/c4w-device-token/{c4WDeviceTokenId}`

Update an existing C4W Device Token

> Body parameter

<h3 id="update-c4w-device-token-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|c4WDeviceTokenId|path|integer(int32)|true|none|
|body|body|[C4WX1APIFeaturesC4WDeviceTokenDtosUpdateC4WDeviceTokenDto](#schemac4wx1apifeaturesc4wdevicetokendtosupdatec4wdevicetokendto)|true|none|

> Example responses

> 500 Response

```json
{
  "status": "Internal Server Error!",
  "code": 500,
  "reason": "Something unexpected has happened",
  "note": "See application log for stack trace."
}
```

<h3 id="update-c4w-device-token-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|204|[No Content](https://tools.ietf.org/html/rfc7231#section-6.3.5)|C4W Device Token updated successfully|None|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|C4W Device Token not found|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## Get C4W Device Token by Old Device Token

<a id="opIdC4WX1APIFeaturesC4WDeviceTokenGetGetByOldDeviceToken"></a>

> Code samples

```shell
# You can also use wget
curl -X GET https://localhost:7055/api/c4w-device-token/old-device-token?oldDeviceToken=string \
  -H 'Accept: application/json'

```

```http
GET https://localhost:7055/api/c4w-device-token/old-device-token?oldDeviceToken=string HTTP/1.1
Host: localhost:7055
Accept: application/json

```

```javascript

const headers = {
  'Accept':'application/json'
};

fetch('https://localhost:7055/api/c4w-device-token/old-device-token?oldDeviceToken=string',
{
  method: 'GET',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```python
import requests
headers = {
  'Accept': 'application/json'
}

r = requests.get('https://localhost:7055/api/c4w-device-token/old-device-token', params={
  'oldDeviceToken': 'string'
}, headers = headers)

print(r.json())

```

`GET /api/c4w-device-token/old-device-token`

Get a C4W Device Token by Old Device Token

<h3 id="get-c4w-device-token-by-old-device-token-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|oldDeviceToken|query|string|true|none|

> Example responses

> 200 Response

```json
{
  "c4WDeviceTokenId": 0,
  "oldDeviceToken": "string",
  "newDeviceToken": "string",
  "clientEnvironment": "string",
  "device": "string",
  "isDeleted": true,
  "createdDate": "2019-08-24T14:15:22Z",
  "createdBy_FK": 0,
  "modifiedDate": "2019-08-24T14:15:22Z",
  "modifiedBy_FK": 0
}
```

<h3 id="get-c4w-device-token-by-old-device-token-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|C4W Device Token retrieved successfully|[C4WX1APIFeaturesC4WDeviceTokenDtosC4WDeviceTokenDto](#schemac4wx1apifeaturesc4wdevicetokendtosc4wdevicetokendto)|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|C4W Device Token not found|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## Create C4W Device Token

<a id="opIdC4WX1APIFeaturesC4WDeviceTokenCreateCreate"></a>

> Code samples

```shell
# You can also use wget
curl -X POST https://localhost:7055/api/c4w-device-token \
  -H 'Content-Type: */*' \
  -H 'Accept: application/problem+json'

```

```http
POST https://localhost:7055/api/c4w-device-token HTTP/1.1
Host: localhost:7055
Content-Type: */*
Accept: application/problem+json

```

```javascript
const inputBody = '{
  "oldDeviceToken": "Old Token",
  "newDeviceToken": "New Token",
  "clientEnvironment": "test env",
  "device": "Iphone",
  "userId": 1
}';
const headers = {
  'Content-Type':'*/*',
  'Accept':'application/problem+json'
};

fetch('https://localhost:7055/api/c4w-device-token',
{
  method: 'POST',
  body: inputBody,
  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```python
import requests
headers = {
  'Content-Type': '*/*',
  'Accept': 'application/problem+json'
}

r = requests.post('https://localhost:7055/api/c4w-device-token', headers = headers)

print(r.json())

```

`POST /api/c4w-device-token`

Create a new C4W Device Token

> Body parameter

<h3 id="create-c4w-device-token-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[C4WX1APIFeaturesC4WDeviceTokenDtosCreateC4WDeviceTokenDto](#schemac4wx1apifeaturesc4wdevicetokendtoscreatec4wdevicetokendto)|true|none|

> Example responses

> 500 Response

```json
{
  "status": "Internal Server Error!",
  "code": 500,
  "reason": "Something unexpected has happened",
  "note": "See application log for stack trace."
}
```

<h3 id="create-c4w-device-token-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|204|[No Content](https://tools.ietf.org/html/rfc7231#section-6.3.5)|No Content|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

<h1 id="c4wx1-api-branch">Branch</h1>

## Update Branch

<a id="opIdC4WX1APIFeaturesBranchUpdateUpdate"></a>

> Code samples

```shell
# You can also use wget
curl -X PUT https://localhost:7055/api/branch/{branchID} \
  -H 'Content-Type: */*' \
  -H 'Accept: application/problem+json'

```

```http
PUT https://localhost:7055/api/branch/{branchID} HTTP/1.1
Host: localhost:7055
Content-Type: */*
Accept: application/problem+json

```

```javascript
const inputBody = '{
  "branchName": "BranchName",
  "address1": "Address1",
  "address2": "Address2",
  "address3": "Address3",
  "contact": "Contact",
  "email": "test@test.com",
  "status": "Active",
  "currencyID_FK": 1,
  "userId": 1,
  "userDataList": [
    {
      "userId": 1,
      "firstName": null,
      "lastName": null
    }
  ]
}';
const headers = {
  'Content-Type':'*/*',
  'Accept':'application/problem+json'
};

fetch('https://localhost:7055/api/branch/{branchID}',
{
  method: 'PUT',
  body: inputBody,
  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```python
import requests
headers = {
  'Content-Type': '*/*',
  'Accept': 'application/problem+json'
}

r = requests.put('https://localhost:7055/api/branch/{branchID}', headers = headers)

print(r.json())

```

`PUT /api/branch/{branchID}`

Update an existing Branch by its ID

> Body parameter

<h3 id="update-branch-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|branchID|path|integer(int32)|true|none|
|body|body|[C4WX1APIFeaturesBranchDtosUpdateBranchDto](#schemac4wx1apifeaturesbranchdtosupdatebranchdto)|true|none|

> Example responses

> 500 Response

```json
{
  "status": "Internal Server Error!",
  "code": 500,
  "reason": "Something unexpected has happened",
  "note": "See application log for stack trace."
}
```

<h3 id="update-branch-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|204|[No Content](https://tools.ietf.org/html/rfc7231#section-6.3.5)|Branch updated successfully|None|
|400|[Bad Request](https://tools.ietf.org/html/rfc7231#section-6.5.1)|Branch data invalid|None|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Branch not found|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## Get Branch

<a id="opIdC4WX1APIFeaturesBranchGetGetById"></a>

> Code samples

```shell
# You can also use wget
curl -X GET https://localhost:7055/api/branch/{id} \
  -H 'Accept: application/json'

```

```http
GET https://localhost:7055/api/branch/{id} HTTP/1.1
Host: localhost:7055
Accept: application/json

```

```javascript

const headers = {
  'Accept':'application/json'
};

fetch('https://localhost:7055/api/branch/{id}',
{
  method: 'GET',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```python
import requests
headers = {
  'Accept': 'application/json'
}

r = requests.get('https://localhost:7055/api/branch/{id}', headers = headers)

print(r.json())

```

`GET /api/branch/{id}`

Get Branch by its ID

<h3 id="get-branch-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|integer(int32)|true|none|

> Example responses

> 200 Response

```json
{
  "branchID": 0,
  "branchName": "string",
  "address1": "string",
  "address2": "string",
  "address3": "string",
  "contact": "string",
  "email": "string",
  "status": "string",
  "isSystemUsed": true,
  "currencyID_FK": 0,
  "currencyName": "string",
  "canDelete": true,
  "userDataList": [
    {
      "userId": 0,
      "firstName": "string",
      "lastName": "string"
    }
  ]
}
```

<h3 id="get-branch-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Branch retrieved successfully|[C4WX1APIFeaturesBranchDtosBranchDto](#schemac4wx1apifeaturesbranchdtosbranchdto)|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Branch not found|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## Delete Branch

<a id="opIdC4WX1APIFeaturesBranchDeleteDelete"></a>

> Code samples

```shell
# You can also use wget
curl -X DELETE https://localhost:7055/api/branch/{id} \
  -H 'Content-Type: */*' \
  -H 'Accept: application/problem+json'

```

```http
DELETE https://localhost:7055/api/branch/{id} HTTP/1.1
Host: localhost:7055
Content-Type: */*
Accept: application/problem+json

```

```javascript
const inputBody = '{
  "userId": 1
}';
const headers = {
  'Content-Type':'*/*',
  'Accept':'application/problem+json'
};

fetch('https://localhost:7055/api/branch/{id}',
{
  method: 'DELETE',
  body: inputBody,
  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```python
import requests
headers = {
  'Content-Type': '*/*',
  'Accept': 'application/problem+json'
}

r = requests.delete('https://localhost:7055/api/branch/{id}', headers = headers)

print(r.json())

```

`DELETE /api/branch/{id}`

Delete an existing Branch by its ID

> Body parameter

<h3 id="delete-branch-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|integer(int32)|true|none|
|body|body|[C4WX1APIFeaturesBranchDtosDeleteBranchDto](#schemac4wx1apifeaturesbranchdtosdeletebranchdto)|true|none|

> Example responses

> 500 Response

```json
{
  "status": "Internal Server Error!",
  "code": 500,
  "reason": "Something unexpected has happened",
  "note": "See application log for stack trace."
}
```

<h3 id="delete-branch-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|204|[No Content](https://tools.ietf.org/html/rfc7231#section-6.3.5)|Branch deleted successfully|None|
|400|[Bad Request](https://tools.ietf.org/html/rfc7231#section-6.5.1)|Branch cannot be deleted|None|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Branch not found|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## Get Branch Count

<a id="opIdC4WX1APIFeaturesBranchGetGetCount"></a>

> Code samples

```shell
# You can also use wget
curl -X GET https://localhost:7055/api/branch/count \
  -H 'Accept: application/json'

```

```http
GET https://localhost:7055/api/branch/count HTTP/1.1
Host: localhost:7055
Accept: application/json

```

```javascript

const headers = {
  'Accept':'application/json'
};

fetch('https://localhost:7055/api/branch/count',
{
  method: 'GET',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```python
import requests
headers = {
  'Accept': 'application/json'
}

r = requests.get('https://localhost:7055/api/branch/count', headers = headers)

print(r.json())

```

`GET /api/branch/count`

Get number of Branch

> Example responses

> 200 Response

```json
0
```

<h3 id="get-branch-count-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Branch Count retrieved successfully|integer|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## Get Branch List

<a id="opIdC4WX1APIFeaturesBranchGetGetList"></a>

> Code samples

```shell
# You can also use wget
curl -X GET https://localhost:7055/api/branch \
  -H 'Accept: application/json'

```

```http
GET https://localhost:7055/api/branch HTTP/1.1
Host: localhost:7055
Accept: application/json

```

```javascript

const headers = {
  'Accept':'application/json'
};

fetch('https://localhost:7055/api/branch',
{
  method: 'GET',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```python
import requests
headers = {
  'Accept': 'application/json'
}

r = requests.get('https://localhost:7055/api/branch', headers = headers)

print(r.json())

```

`GET /api/branch`

Get a paged and sorted Branch List

<h3 id="get-branch-list-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|pageIndex|query|integer(int32)|false|none|
|pageSize|query|integer(int32)|false|none|
|orderBy|query|string|false|none|

> Example responses

> 200 Response

```json
[
  {
    "branchID": 0,
    "branchName": "string",
    "address1": "string",
    "address2": "string",
    "address3": "string",
    "contact": "string",
    "email": "string",
    "status": "string",
    "isSystemUsed": true,
    "currencyID_FK": 0,
    "currencyName": "string",
    "canDelete": true,
    "userDataList": [
      {
        "userId": 0,
        "firstName": "string",
        "lastName": "string"
      }
    ]
  }
]
```

<h3 id="get-branch-list-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Branch List retrieved successfully|Inline|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<h3 id="get-branch-list-responseschema">Response Schema</h3>

Status Code **200**

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[[C4WX1APIFeaturesBranchDtosBranchDto](#schemac4wx1apifeaturesbranchdtosbranchdto)]|false|none|none|
|» branchID|integer(int32)|false|none|none|
|» branchName|string|false|none|none|
|» address1|string¦null|false|none|none|
|» address2|string¦null|false|none|none|
|» address3|string¦null|false|none|none|
|» contact|string¦null|false|none|none|
|» email|string¦null|false|none|none|
|» status|string|false|none|none|
|» isSystemUsed|boolean|false|none|none|
|» currencyID_FK|integer(int32)¦null|false|none|none|
|» currencyName|string|false|none|none|
|» canDelete|boolean|false|none|none|
|» userDataList|[[C4WX1APIFeaturesBranchDtosBranchUserDto](#schemac4wx1apifeaturesbranchdtosbranchuserdto)]|false|none|none|
|»» userId|integer(int32)|false|none|none|
|»» firstName|string|false|none|none|
|»» lastName|string|false|none|none|

<aside class="success">
This operation does not require authentication
</aside>

## Create Branch

<a id="opIdC4WX1APIFeaturesBranchCreateCreate"></a>

> Code samples

```shell
# You can also use wget
curl -X POST https://localhost:7055/api/branch \
  -H 'Content-Type: */*' \
  -H 'Accept: application/problem+json'

```

```http
POST https://localhost:7055/api/branch HTTP/1.1
Host: localhost:7055
Content-Type: */*
Accept: application/problem+json

```

```javascript
const inputBody = '{
  "branchID": 0,
  "branchName": "BranchName",
  "address1": "Address1",
  "address2": "Address2",
  "address3": "Address3",
  "contact": "Contact",
  "email": "test@test.com",
  "status": "Active",
  "currencyID_FK": 1,
  "userId": 1,
  "userDataList": [
    {
      "userId": 1,
      "firstName": null,
      "lastName": null
    }
  ]
}';
const headers = {
  'Content-Type':'*/*',
  'Accept':'application/problem+json'
};

fetch('https://localhost:7055/api/branch',
{
  method: 'POST',
  body: inputBody,
  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```python
import requests
headers = {
  'Content-Type': '*/*',
  'Accept': 'application/problem+json'
}

r = requests.post('https://localhost:7055/api/branch', headers = headers)

print(r.json())

```

`POST /api/branch`

Create a new Branch

> Body parameter

<h3 id="create-branch-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[C4WX1APIFeaturesBranchDtosCreateBranchDto](#schemac4wx1apifeaturesbranchdtoscreatebranchdto)|true|none|

> Example responses

> 500 Response

```json
{
  "status": "Internal Server Error!",
  "code": 500,
  "reason": "Something unexpected has happened",
  "note": "See application log for stack trace."
}
```

<h3 id="create-branch-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|204|[No Content](https://tools.ietf.org/html/rfc7231#section-6.3.5)|Branch created successfully|None|
|400|[Bad Request](https://tools.ietf.org/html/rfc7231#section-6.5.1)|Branch data invalid|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## Get Branch List for Control

<a id="opIdC4WX1APIFeaturesBranchGetGetListForControl"></a>

> Code samples

```shell
# You can also use wget
curl -X GET https://localhost:7055/api/branch/for-control \
  -H 'Accept: application/json'

```

```http
GET https://localhost:7055/api/branch/for-control HTTP/1.1
Host: localhost:7055
Accept: application/json

```

```javascript

const headers = {
  'Accept':'application/json'
};

fetch('https://localhost:7055/api/branch/for-control',
{
  method: 'GET',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```python
import requests
headers = {
  'Accept': 'application/json'
}

r = requests.get('https://localhost:7055/api/branch/for-control', headers = headers)

print(r.json())

```

`GET /api/branch/for-control`

Get sorted Branch List for Control

> Example responses

> 200 Response

```json
[
  {
    "branchID": 0,
    "branchName": "string",
    "address1": "string",
    "address2": "string",
    "address3": "string",
    "contact": "string",
    "email": "string",
    "status": "string",
    "isSystemUsed": true,
    "currencyID_FK": 0,
    "currencyName": "string",
    "canDelete": true,
    "userDataList": [
      {
        "userId": 0,
        "firstName": "string",
        "lastName": "string"
      }
    ]
  }
]
```

<h3 id="get-branch-list-for-control-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Branch List retrieved successfully|Inline|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<h3 id="get-branch-list-for-control-responseschema">Response Schema</h3>

Status Code **200**

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[[C4WX1APIFeaturesBranchDtosBranchDto](#schemac4wx1apifeaturesbranchdtosbranchdto)]|false|none|none|
|» branchID|integer(int32)|false|none|none|
|» branchName|string|false|none|none|
|» address1|string¦null|false|none|none|
|» address2|string¦null|false|none|none|
|» address3|string¦null|false|none|none|
|» contact|string¦null|false|none|none|
|» email|string¦null|false|none|none|
|» status|string|false|none|none|
|» isSystemUsed|boolean|false|none|none|
|» currencyID_FK|integer(int32)¦null|false|none|none|
|» currencyName|string|false|none|none|
|» canDelete|boolean|false|none|none|
|» userDataList|[[C4WX1APIFeaturesBranchDtosBranchUserDto](#schemac4wx1apifeaturesbranchdtosbranchuserdto)]|false|none|none|
|»» userId|integer(int32)|false|none|none|
|»» firstName|string|false|none|none|
|»» lastName|string|false|none|none|

<aside class="success">
This operation does not require authentication
</aside>

<h1 id="c4wx1-api-billing-proposal">Billing-Proposal</h1>

## Update Billing Proposal

<a id="opIdC4WX1APIFeaturesBillingProposalUpdateUpdate"></a>

> Code samples

```shell
# You can also use wget
curl -X PUT https://localhost:7055/api/billing-proposal/{id} \
  -H 'Content-Type: */*' \
  -H 'Accept: application/problem+json'

```

```http
PUT https://localhost:7055/api/billing-proposal/{id} HTTP/1.1
Host: localhost:7055
Content-Type: */*
Accept: application/problem+json

```

```javascript
const inputBody = '{
  "patientID_FK": 1,
  "title": "Title",
  "sendEmail": true,
  "emailPatient": true,
  "emailTo": "test-to@gmail.com",
  "emailCC": "test-cc@gmail.com",
  "emailBCC": "test-bcc@gmail.com",
  "currencyID_FK": 1,
  "status": "Active",
  "groupNumber": "1",
  "version": 1,
  "proposalType": "ProposalType",
  "userId": 1,
  "serviceList": [
    {
      "billingInvoiceServiceID": 0,
      "billingProposalID_FK": 0,
      "serviceID_FK": 1,
      "categoryId": 0,
      "title": null,
      "startDate": "2025-02-21T20:43:16.8101995+08:00",
      "endDate": "2025-02-21T20:43:16.8124593+08:00",
      "unitCost": 0,
      "duration1": "Duration1",
      "duration2": "Duration2",
      "visit": 1,
      "session": 0,
      "discount": 0,
      "serviceDescription": "ServiceDescription",
      "categoryName": null
    }
  ]
}';
const headers = {
  'Content-Type':'*/*',
  'Accept':'application/problem+json'
};

fetch('https://localhost:7055/api/billing-proposal/{id}',
{
  method: 'PUT',
  body: inputBody,
  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```python
import requests
headers = {
  'Content-Type': '*/*',
  'Accept': 'application/problem+json'
}

r = requests.put('https://localhost:7055/api/billing-proposal/{id}', headers = headers)

print(r.json())

```

`PUT /api/billing-proposal/{id}`

Update Billing Proposal by its ID

> Body parameter

<h3 id="update-billing-proposal-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|integer(int32)|true|none|
|body|body|[C4WX1APIFeaturesBillingProposalDtosUpdateBillingProposalDto](#schemac4wx1apifeaturesbillingproposaldtosupdatebillingproposaldto)|true|none|

> Example responses

> 500 Response

```json
{
  "status": "Internal Server Error!",
  "code": 500,
  "reason": "Something unexpected has happened",
  "note": "See application log for stack trace."
}
```

<h3 id="update-billing-proposal-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|204|[No Content](https://tools.ietf.org/html/rfc7231#section-6.3.5)|Billing Proposal updated successfully|None|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Billing Proposal not found|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## Get Billing Proposal

<a id="opIdC4WX1APIFeaturesBillingProposalGetGetById"></a>

> Code samples

```shell
# You can also use wget
curl -X GET https://localhost:7055/api/billing-proposal/{id} \
  -H 'Accept: application/json'

```

```http
GET https://localhost:7055/api/billing-proposal/{id} HTTP/1.1
Host: localhost:7055
Accept: application/json

```

```javascript

const headers = {
  'Accept':'application/json'
};

fetch('https://localhost:7055/api/billing-proposal/{id}',
{
  method: 'GET',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```python
import requests
headers = {
  'Accept': 'application/json'
}

r = requests.get('https://localhost:7055/api/billing-proposal/{id}', headers = headers)

print(r.json())

```

`GET /api/billing-proposal/{id}`

Get Billing Proposal by its ID

<h3 id="get-billing-proposal-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|integer(int32)|true|none|

> Example responses

> 200 Response

```json
{
  "billingProposalID": 0,
  "patientID_FK": 0,
  "proposalNumber": "string",
  "title": "string",
  "sendEmail": true,
  "emailPatient": true,
  "emailTo": "string",
  "emailCC": "string",
  "emailBCC": "string",
  "currencyID_FK": 0,
  "currencyCode": "string",
  "totalCost": 0,
  "status": "string",
  "groupNumber": "string",
  "version": 0,
  "createdDate": "2019-08-24T14:15:22Z",
  "createdBy_FK": 0,
  "modifiedDate": "2019-08-24T14:15:22Z",
  "modifiedBy_FK": 0,
  "isDeleted": true,
  "proposalType": "string",
  "patientData": {
    "patientID": 0,
    "firstName": "string",
    "lastName": "string",
    "photo": "string",
    "mailingAddress1": "string",
    "mailingAddress2": "string",
    "mailingAddress3": "string",
    "mailingPostalCode": "string",
    "profile": {
      "email": "string"
    }
  },
  "createdByData": {
    "userId": 0,
    "firstName": "string",
    "lastName": "string",
    "photo": "string",
    "email": "string"
  },
  "modifiedByData": {
    "userId": 0,
    "firstName": "string",
    "lastName": "string",
    "photo": "string",
    "email": "string"
  },
  "serviceList": [
    {
      "billingInvoiceServiceID": 0,
      "billingProposalID_FK": 0,
      "serviceID_FK": 0,
      "categoryId": 0,
      "title": "string",
      "startDate": "2019-08-24T14:15:22Z",
      "endDate": "2019-08-24T14:15:22Z",
      "unitCost": 0,
      "duration1": "string",
      "duration2": "string",
      "visit": 0,
      "session": 0,
      "discount": 0,
      "serviceDescription": "string",
      "categoryName": "string"
    }
  ]
}
```

<h3 id="get-billing-proposal-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Billing Proposal retrieved succesfully|[C4WX1APIFeaturesBillingProposalDtosBillingProposalDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposaldto)|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Billing Proposal not found|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## Delete Billing Proposal

<a id="opIdC4WX1APIFeaturesBillingProposalDeleteDelete"></a>

> Code samples

```shell
# You can also use wget
curl -X DELETE https://localhost:7055/api/billing-proposal/{id} \
  -H 'Content-Type: */*' \
  -H 'Accept: application/json'

```

```http
DELETE https://localhost:7055/api/billing-proposal/{id} HTTP/1.1
Host: localhost:7055
Content-Type: */*
Accept: application/json

```

```javascript
const inputBody = '{
  "userId": 1
}';
const headers = {
  'Content-Type':'*/*',
  'Accept':'application/json'
};

fetch('https://localhost:7055/api/billing-proposal/{id}',
{
  method: 'DELETE',
  body: inputBody,
  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```python
import requests
headers = {
  'Content-Type': '*/*',
  'Accept': 'application/json'
}

r = requests.delete('https://localhost:7055/api/billing-proposal/{id}', headers = headers)

print(r.json())

```

`DELETE /api/billing-proposal/{id}`

Delete Billing Proposal by its ID

> Body parameter

<h3 id="delete-billing-proposal-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|integer(int32)|true|none|
|body|body|[C4WX1APIFeaturesBillingProposalDtosDeleteBillingProposalDto](#schemac4wx1apifeaturesbillingproposaldtosdeletebillingproposaldto)|true|none|

> Example responses

> 500 Response

```json
{
  "status": "Internal Server Error!",
  "code": 500,
  "reason": "Something unexpected has happened",
  "note": "See application log for stack trace."
}
```

<h3 id="delete-billing-proposal-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|204|[No Content](https://tools.ietf.org/html/rfc7231#section-6.3.5)|No Content|None|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Billing Proposal not found|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## Update Billing Proposal Status

<a id="opIdC4WX1APIFeaturesBillingProposalUpdateUpdateStatus"></a>

> Code samples

```shell
# You can also use wget
curl -X PUT https://localhost:7055/api/billing-proposal/{id}/status \
  -H 'Content-Type: */*' \
  -H 'Accept: application/problem+json'

```

```http
PUT https://localhost:7055/api/billing-proposal/{id}/status HTTP/1.1
Host: localhost:7055
Content-Type: */*
Accept: application/problem+json

```

```javascript
const inputBody = '{
  "userId": 1,
  "status": "Success"
}';
const headers = {
  'Content-Type':'*/*',
  'Accept':'application/problem+json'
};

fetch('https://localhost:7055/api/billing-proposal/{id}/status',
{
  method: 'PUT',
  body: inputBody,
  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```python
import requests
headers = {
  'Content-Type': '*/*',
  'Accept': 'application/problem+json'
}

r = requests.put('https://localhost:7055/api/billing-proposal/{id}/status', headers = headers)

print(r.json())

```

`PUT /api/billing-proposal/{id}/status`

Update Billing Proposal Status by its ID

> Body parameter

<h3 id="update-billing-proposal-status-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|integer(int32)|true|none|
|body|body|[C4WX1APIFeaturesBillingProposalDtosUpdateBillingProposalStatusDto](#schemac4wx1apifeaturesbillingproposaldtosupdatebillingproposalstatusdto)|true|none|

> Example responses

> 500 Response

```json
{
  "status": "Internal Server Error!",
  "code": 500,
  "reason": "Something unexpected has happened",
  "note": "See application log for stack trace."
}
```

<h3 id="update-billing-proposal-status-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|204|[No Content](https://tools.ietf.org/html/rfc7231#section-6.3.5)|No Content|None|
|400|[Bad Request](https://tools.ietf.org/html/rfc7231#section-6.5.1)|Billing Proposal not found|None|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Billing Proposal Status invalid|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## Get Active Billing Proposal List

<a id="opIdC4WX1APIFeaturesBillingProposalGetGetActiveList"></a>

> Code samples

```shell
# You can also use wget
curl -X GET https://localhost:7055/api/billing-proposal/active/{patientId} \
  -H 'Accept: application/json'

```

```http
GET https://localhost:7055/api/billing-proposal/active/{patientId} HTTP/1.1
Host: localhost:7055
Accept: application/json

```

```javascript

const headers = {
  'Accept':'application/json'
};

fetch('https://localhost:7055/api/billing-proposal/active/{patientId}',
{
  method: 'GET',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```python
import requests
headers = {
  'Accept': 'application/json'
}

r = requests.get('https://localhost:7055/api/billing-proposal/active/{patientId}', headers = headers)

print(r.json())

```

`GET /api/billing-proposal/active/{patientId}`

Get filtered and sorted Active Billing Proposal List by PatientID

<h3 id="get-active-billing-proposal-list-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|patientId|path|integer(int32)|true|none|

> Example responses

> 200 Response

```json
[
  {
    "billingProposalID": 0,
    "patientID_FK": 0,
    "proposalNumber": "string",
    "title": "string",
    "sendEmail": true,
    "emailPatient": true,
    "emailTo": "string",
    "emailCC": "string",
    "emailBCC": "string",
    "currencyID_FK": 0,
    "currencyCode": "string",
    "totalCost": 0,
    "status": "string",
    "groupNumber": "string",
    "version": 0,
    "createdDate": "2019-08-24T14:15:22Z",
    "createdBy_FK": 0,
    "modifiedDate": "2019-08-24T14:15:22Z",
    "modifiedBy_FK": 0,
    "isDeleted": true,
    "proposalType": "string",
    "patientData": {
      "patientID": 0,
      "firstName": "string",
      "lastName": "string",
      "photo": "string",
      "mailingAddress1": "string",
      "mailingAddress2": "string",
      "mailingAddress3": "string",
      "mailingPostalCode": "string",
      "profile": {
        "email": "string"
      }
    },
    "createdByData": {
      "userId": 0,
      "firstName": "string",
      "lastName": "string",
      "photo": "string",
      "email": "string"
    },
    "modifiedByData": {
      "userId": 0,
      "firstName": "string",
      "lastName": "string",
      "photo": "string",
      "email": "string"
    },
    "serviceList": [
      {
        "billingInvoiceServiceID": 0,
        "billingProposalID_FK": 0,
        "serviceID_FK": 0,
        "categoryId": 0,
        "title": "string",
        "startDate": "2019-08-24T14:15:22Z",
        "endDate": "2019-08-24T14:15:22Z",
        "unitCost": 0,
        "duration1": "string",
        "duration2": "string",
        "visit": 0,
        "session": 0,
        "discount": 0,
        "serviceDescription": "string",
        "categoryName": "string"
      }
    ]
  }
]
```

<h3 id="get-active-billing-proposal-list-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Billing Proposal List retrieved successfully|Inline|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<h3 id="get-active-billing-proposal-list-responseschema">Response Schema</h3>

Status Code **200**

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[[C4WX1APIFeaturesBillingProposalDtosBillingProposalDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposaldto)]|false|none|none|
|» billingProposalID|integer(int32)|false|none|none|
|» patientID_FK|integer(int32)|false|none|none|
|» proposalNumber|string|false|none|none|
|» title|string|false|none|none|
|» sendEmail|boolean¦null|false|none|none|
|» emailPatient|boolean¦null|false|none|none|
|» emailTo|string¦null|false|none|none|
|» emailCC|string¦null|false|none|none|
|» emailBCC|string¦null|false|none|none|
|» currencyID_FK|integer(int32)|false|none|none|
|» currencyCode|string|false|none|none|
|» totalCost|number(decimal)|false|none|none|
|» status|string|false|none|none|
|» groupNumber|string|false|none|none|
|» version|integer|false|none|none|
|» createdDate|string(date-time)|false|none|none|
|» createdBy_FK|integer(int32)|false|none|none|
|» modifiedDate|string(date-time)¦null|false|none|none|
|» modifiedBy_FK|integer(int32)¦null|false|none|none|
|» isDeleted|boolean|false|none|none|
|» proposalType|string|false|none|none|
|» patientData|[C4WX1APIFeaturesBillingProposalDtosBillingProposalPatientDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposalpatientdto)|false|none|none|
|»» patientID|integer(int32)|false|none|none|
|»» firstName|string|false|none|none|
|»» lastName|string|false|none|none|
|»» photo|string¦null|false|none|none|
|»» mailingAddress1|string¦null|false|none|none|
|»» mailingAddress2|string¦null|false|none|none|
|»» mailingAddress3|string¦null|false|none|none|
|»» mailingPostalCode|string¦null|false|none|none|
|»» profile|[C4WX1APIFeaturesBillingProposalDtosBillingProposalPatientProfileDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposalpatientprofiledto)¦null|false|none|none|
|»»» email|string¦null|false|none|none|
|» createdByData|[C4WX1APIFeaturesBillingProposalDtosBillingProposalUserDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposaluserdto)|false|none|none|
|»» userId|integer(int32)|false|none|none|
|»» firstName|string|false|none|none|
|»» lastName|string|false|none|none|
|»» photo|string¦null|false|none|none|
|»» email|string|false|none|none|
|» modifiedByData|[C4WX1APIFeaturesBillingProposalDtosBillingProposalUserDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposaluserdto)¦null|false|none|none|
|»» userId|integer(int32)|false|none|none|
|»» firstName|string|false|none|none|
|»» lastName|string|false|none|none|
|»» photo|string¦null|false|none|none|
|»» email|string|false|none|none|
|» serviceList|[[C4WX1APIFeaturesBillingProposalDtosBillingProposalServiceDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposalservicedto)]|false|none|none|
|»» billingInvoiceServiceID|integer(int32)|false|none|none|
|»» billingProposalID_FK|integer(int32)|false|none|none|
|»» serviceID_FK|integer(int32)|false|none|none|
|»» categoryId|integer(int32)|false|none|none|
|»» title|string|false|none|none|
|»» startDate|string(date-time)|false|none|none|
|»» endDate|string(date-time)|false|none|none|
|»» unitCost|number(decimal)|false|none|none|
|»» duration1|string¦null|false|none|none|
|»» duration2|string¦null|false|none|none|
|»» visit|integer(int32)|false|none|none|
|»» session|integer(int32)|false|none|none|
|»» discount|number(decimal)|false|none|none|
|»» serviceDescription|string¦null|false|none|none|
|»» categoryName|string|false|none|none|

<aside class="success">
This operation does not require authentication
</aside>

## Get All Billing Proposal List

<a id="opIdC4WX1APIFeaturesBillingProposalGetGetAllList"></a>

> Code samples

```shell
# You can also use wget
curl -X GET https://localhost:7055/api/billing-proposal/all \
  -H 'Accept: application/json'

```

```http
GET https://localhost:7055/api/billing-proposal/all HTTP/1.1
Host: localhost:7055
Accept: application/json

```

```javascript

const headers = {
  'Accept':'application/json'
};

fetch('https://localhost:7055/api/billing-proposal/all',
{
  method: 'GET',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```python
import requests
headers = {
  'Accept': 'application/json'
}

r = requests.get('https://localhost:7055/api/billing-proposal/all', headers = headers)

print(r.json())

```

`GET /api/billing-proposal/all`

Get all filtered and sorted Billing Proposal List

<h3 id="get-all-billing-proposal-list-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|keyword|query|string|false|none|
|status|query|string|false|none|
|orderBy|query|string|false|none|

> Example responses

> 200 Response

```json
[
  {
    "billingProposalID": 0,
    "patientID_FK": 0,
    "proposalNumber": "string",
    "title": "string",
    "sendEmail": true,
    "emailPatient": true,
    "emailTo": "string",
    "emailCC": "string",
    "emailBCC": "string",
    "currencyID_FK": 0,
    "currencyCode": "string",
    "totalCost": 0,
    "status": "string",
    "groupNumber": "string",
    "version": 0,
    "createdDate": "2019-08-24T14:15:22Z",
    "createdBy_FK": 0,
    "modifiedDate": "2019-08-24T14:15:22Z",
    "modifiedBy_FK": 0,
    "isDeleted": true,
    "proposalType": "string",
    "patientData": {
      "patientID": 0,
      "firstName": "string",
      "lastName": "string",
      "photo": "string",
      "mailingAddress1": "string",
      "mailingAddress2": "string",
      "mailingAddress3": "string",
      "mailingPostalCode": "string",
      "profile": {
        "email": "string"
      }
    },
    "createdByData": {
      "userId": 0,
      "firstName": "string",
      "lastName": "string",
      "photo": "string",
      "email": "string"
    },
    "modifiedByData": {
      "userId": 0,
      "firstName": "string",
      "lastName": "string",
      "photo": "string",
      "email": "string"
    },
    "serviceList": [
      {
        "billingInvoiceServiceID": 0,
        "billingProposalID_FK": 0,
        "serviceID_FK": 0,
        "categoryId": 0,
        "title": "string",
        "startDate": "2019-08-24T14:15:22Z",
        "endDate": "2019-08-24T14:15:22Z",
        "unitCost": 0,
        "duration1": "string",
        "duration2": "string",
        "visit": 0,
        "session": 0,
        "discount": 0,
        "serviceDescription": "string",
        "categoryName": "string"
      }
    ]
  }
]
```

<h3 id="get-all-billing-proposal-list-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Billing Proposal List retrieved successfully|Inline|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<h3 id="get-all-billing-proposal-list-responseschema">Response Schema</h3>

Status Code **200**

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[[C4WX1APIFeaturesBillingProposalDtosBillingProposalDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposaldto)]|false|none|none|
|» billingProposalID|integer(int32)|false|none|none|
|» patientID_FK|integer(int32)|false|none|none|
|» proposalNumber|string|false|none|none|
|» title|string|false|none|none|
|» sendEmail|boolean¦null|false|none|none|
|» emailPatient|boolean¦null|false|none|none|
|» emailTo|string¦null|false|none|none|
|» emailCC|string¦null|false|none|none|
|» emailBCC|string¦null|false|none|none|
|» currencyID_FK|integer(int32)|false|none|none|
|» currencyCode|string|false|none|none|
|» totalCost|number(decimal)|false|none|none|
|» status|string|false|none|none|
|» groupNumber|string|false|none|none|
|» version|integer|false|none|none|
|» createdDate|string(date-time)|false|none|none|
|» createdBy_FK|integer(int32)|false|none|none|
|» modifiedDate|string(date-time)¦null|false|none|none|
|» modifiedBy_FK|integer(int32)¦null|false|none|none|
|» isDeleted|boolean|false|none|none|
|» proposalType|string|false|none|none|
|» patientData|[C4WX1APIFeaturesBillingProposalDtosBillingProposalPatientDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposalpatientdto)|false|none|none|
|»» patientID|integer(int32)|false|none|none|
|»» firstName|string|false|none|none|
|»» lastName|string|false|none|none|
|»» photo|string¦null|false|none|none|
|»» mailingAddress1|string¦null|false|none|none|
|»» mailingAddress2|string¦null|false|none|none|
|»» mailingAddress3|string¦null|false|none|none|
|»» mailingPostalCode|string¦null|false|none|none|
|»» profile|[C4WX1APIFeaturesBillingProposalDtosBillingProposalPatientProfileDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposalpatientprofiledto)¦null|false|none|none|
|»»» email|string¦null|false|none|none|
|» createdByData|[C4WX1APIFeaturesBillingProposalDtosBillingProposalUserDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposaluserdto)|false|none|none|
|»» userId|integer(int32)|false|none|none|
|»» firstName|string|false|none|none|
|»» lastName|string|false|none|none|
|»» photo|string¦null|false|none|none|
|»» email|string|false|none|none|
|» modifiedByData|[C4WX1APIFeaturesBillingProposalDtosBillingProposalUserDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposaluserdto)¦null|false|none|none|
|»» userId|integer(int32)|false|none|none|
|»» firstName|string|false|none|none|
|»» lastName|string|false|none|none|
|»» photo|string¦null|false|none|none|
|»» email|string|false|none|none|
|» serviceList|[[C4WX1APIFeaturesBillingProposalDtosBillingProposalServiceDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposalservicedto)]|false|none|none|
|»» billingInvoiceServiceID|integer(int32)|false|none|none|
|»» billingProposalID_FK|integer(int32)|false|none|none|
|»» serviceID_FK|integer(int32)|false|none|none|
|»» categoryId|integer(int32)|false|none|none|
|»» title|string|false|none|none|
|»» startDate|string(date-time)|false|none|none|
|»» endDate|string(date-time)|false|none|none|
|»» unitCost|number(decimal)|false|none|none|
|»» duration1|string¦null|false|none|none|
|»» duration2|string¦null|false|none|none|
|»» visit|integer(int32)|false|none|none|
|»» session|integer(int32)|false|none|none|
|»» discount|number(decimal)|false|none|none|
|»» serviceDescription|string¦null|false|none|none|
|»» categoryName|string|false|none|none|

<aside class="success">
This operation does not require authentication
</aside>

## Get Billing Proposal Count

<a id="opIdC4WX1APIFeaturesBillingProposalGetGetCount"></a>

> Code samples

```shell
# You can also use wget
curl -X GET https://localhost:7055/api/billing-proposal/count \
  -H 'Accept: application/json'

```

```http
GET https://localhost:7055/api/billing-proposal/count HTTP/1.1
Host: localhost:7055
Accept: application/json

```

```javascript

const headers = {
  'Accept':'application/json'
};

fetch('https://localhost:7055/api/billing-proposal/count',
{
  method: 'GET',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```python
import requests
headers = {
  'Accept': 'application/json'
}

r = requests.get('https://localhost:7055/api/billing-proposal/count', headers = headers)

print(r.json())

```

`GET /api/billing-proposal/count`

Get filtered Billing Proposal Count

<h3 id="get-billing-proposal-count-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|keyword|query|string|false|none|
|status|query|string|false|none|

> Example responses

> 200 Response

```json
0
```

<h3 id="get-billing-proposal-count-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Billing Proposal Count retrieved successfully|integer|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## Get History Billing Proposal List

<a id="opIdC4WX1APIFeaturesBillingProposalGetGetHistoryList"></a>

> Code samples

```shell
# You can also use wget
curl -X GET https://localhost:7055/api/billing-proposal/history \
  -H 'Accept: application/json'

```

```http
GET https://localhost:7055/api/billing-proposal/history HTTP/1.1
Host: localhost:7055
Accept: application/json

```

```javascript

const headers = {
  'Accept':'application/json'
};

fetch('https://localhost:7055/api/billing-proposal/history',
{
  method: 'GET',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```python
import requests
headers = {
  'Accept': 'application/json'
}

r = requests.get('https://localhost:7055/api/billing-proposal/history', headers = headers)

print(r.json())

```

`GET /api/billing-proposal/history`

Get filtered and sorted History Billing Proposal List

<h3 id="get-history-billing-proposal-list-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|groupNumber|query|string|false|none|
|orderBy|query|string|false|none|

> Example responses

> 200 Response

```json
[
  {
    "billingProposalID": 0,
    "patientID_FK": 0,
    "proposalNumber": "string",
    "title": "string",
    "sendEmail": true,
    "emailPatient": true,
    "emailTo": "string",
    "emailCC": "string",
    "emailBCC": "string",
    "currencyID_FK": 0,
    "currencyCode": "string",
    "totalCost": 0,
    "status": "string",
    "groupNumber": "string",
    "version": 0,
    "createdDate": "2019-08-24T14:15:22Z",
    "createdBy_FK": 0,
    "modifiedDate": "2019-08-24T14:15:22Z",
    "modifiedBy_FK": 0,
    "isDeleted": true,
    "proposalType": "string",
    "patientData": {
      "patientID": 0,
      "firstName": "string",
      "lastName": "string",
      "photo": "string",
      "mailingAddress1": "string",
      "mailingAddress2": "string",
      "mailingAddress3": "string",
      "mailingPostalCode": "string",
      "profile": {
        "email": "string"
      }
    },
    "createdByData": {
      "userId": 0,
      "firstName": "string",
      "lastName": "string",
      "photo": "string",
      "email": "string"
    },
    "modifiedByData": {
      "userId": 0,
      "firstName": "string",
      "lastName": "string",
      "photo": "string",
      "email": "string"
    },
    "serviceList": [
      {
        "billingInvoiceServiceID": 0,
        "billingProposalID_FK": 0,
        "serviceID_FK": 0,
        "categoryId": 0,
        "title": "string",
        "startDate": "2019-08-24T14:15:22Z",
        "endDate": "2019-08-24T14:15:22Z",
        "unitCost": 0,
        "duration1": "string",
        "duration2": "string",
        "visit": 0,
        "session": 0,
        "discount": 0,
        "serviceDescription": "string",
        "categoryName": "string"
      }
    ]
  }
]
```

<h3 id="get-history-billing-proposal-list-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Billing Proposal List retrieved successfully|Inline|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<h3 id="get-history-billing-proposal-list-responseschema">Response Schema</h3>

Status Code **200**

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[[C4WX1APIFeaturesBillingProposalDtosBillingProposalDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposaldto)]|false|none|none|
|» billingProposalID|integer(int32)|false|none|none|
|» patientID_FK|integer(int32)|false|none|none|
|» proposalNumber|string|false|none|none|
|» title|string|false|none|none|
|» sendEmail|boolean¦null|false|none|none|
|» emailPatient|boolean¦null|false|none|none|
|» emailTo|string¦null|false|none|none|
|» emailCC|string¦null|false|none|none|
|» emailBCC|string¦null|false|none|none|
|» currencyID_FK|integer(int32)|false|none|none|
|» currencyCode|string|false|none|none|
|» totalCost|number(decimal)|false|none|none|
|» status|string|false|none|none|
|» groupNumber|string|false|none|none|
|» version|integer|false|none|none|
|» createdDate|string(date-time)|false|none|none|
|» createdBy_FK|integer(int32)|false|none|none|
|» modifiedDate|string(date-time)¦null|false|none|none|
|» modifiedBy_FK|integer(int32)¦null|false|none|none|
|» isDeleted|boolean|false|none|none|
|» proposalType|string|false|none|none|
|» patientData|[C4WX1APIFeaturesBillingProposalDtosBillingProposalPatientDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposalpatientdto)|false|none|none|
|»» patientID|integer(int32)|false|none|none|
|»» firstName|string|false|none|none|
|»» lastName|string|false|none|none|
|»» photo|string¦null|false|none|none|
|»» mailingAddress1|string¦null|false|none|none|
|»» mailingAddress2|string¦null|false|none|none|
|»» mailingAddress3|string¦null|false|none|none|
|»» mailingPostalCode|string¦null|false|none|none|
|»» profile|[C4WX1APIFeaturesBillingProposalDtosBillingProposalPatientProfileDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposalpatientprofiledto)¦null|false|none|none|
|»»» email|string¦null|false|none|none|
|» createdByData|[C4WX1APIFeaturesBillingProposalDtosBillingProposalUserDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposaluserdto)|false|none|none|
|»» userId|integer(int32)|false|none|none|
|»» firstName|string|false|none|none|
|»» lastName|string|false|none|none|
|»» photo|string¦null|false|none|none|
|»» email|string|false|none|none|
|» modifiedByData|[C4WX1APIFeaturesBillingProposalDtosBillingProposalUserDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposaluserdto)¦null|false|none|none|
|»» userId|integer(int32)|false|none|none|
|»» firstName|string|false|none|none|
|»» lastName|string|false|none|none|
|»» photo|string¦null|false|none|none|
|»» email|string|false|none|none|
|» serviceList|[[C4WX1APIFeaturesBillingProposalDtosBillingProposalServiceDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposalservicedto)]|false|none|none|
|»» billingInvoiceServiceID|integer(int32)|false|none|none|
|»» billingProposalID_FK|integer(int32)|false|none|none|
|»» serviceID_FK|integer(int32)|false|none|none|
|»» categoryId|integer(int32)|false|none|none|
|»» title|string|false|none|none|
|»» startDate|string(date-time)|false|none|none|
|»» endDate|string(date-time)|false|none|none|
|»» unitCost|number(decimal)|false|none|none|
|»» duration1|string¦null|false|none|none|
|»» duration2|string¦null|false|none|none|
|»» visit|integer(int32)|false|none|none|
|»» session|integer(int32)|false|none|none|
|»» discount|number(decimal)|false|none|none|
|»» serviceDescription|string¦null|false|none|none|
|»» categoryName|string|false|none|none|

<aside class="success">
This operation does not require authentication
</aside>

## Get Billing Proposal List

<a id="opIdC4WX1APIFeaturesBillingProposalGetGetList"></a>

> Code samples

```shell
# You can also use wget
curl -X GET https://localhost:7055/api/billing-proposal \
  -H 'Accept: application/json'

```

```http
GET https://localhost:7055/api/billing-proposal HTTP/1.1
Host: localhost:7055
Accept: application/json

```

```javascript

const headers = {
  'Accept':'application/json'
};

fetch('https://localhost:7055/api/billing-proposal',
{
  method: 'GET',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```python
import requests
headers = {
  'Accept': 'application/json'
}

r = requests.get('https://localhost:7055/api/billing-proposal', headers = headers)

print(r.json())

```

`GET /api/billing-proposal`

Get a filtered, paged and sorted list of Billing Proposals

<h3 id="get-billing-proposal-list-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|keyword|query|string|false|none|
|status|query|string|false|none|
|pageIndex|query|integer(int32)|false|none|
|pageSize|query|integer(int32)|false|none|
|orderBy|query|string|false|none|

> Example responses

> 200 Response

```json
[
  {
    "billingProposalID": 0,
    "patientID_FK": 0,
    "proposalNumber": "string",
    "title": "string",
    "sendEmail": true,
    "emailPatient": true,
    "emailTo": "string",
    "emailCC": "string",
    "emailBCC": "string",
    "currencyID_FK": 0,
    "currencyCode": "string",
    "totalCost": 0,
    "status": "string",
    "groupNumber": "string",
    "version": 0,
    "createdDate": "2019-08-24T14:15:22Z",
    "createdBy_FK": 0,
    "modifiedDate": "2019-08-24T14:15:22Z",
    "modifiedBy_FK": 0,
    "isDeleted": true,
    "proposalType": "string",
    "patientData": {
      "patientID": 0,
      "firstName": "string",
      "lastName": "string",
      "photo": "string",
      "mailingAddress1": "string",
      "mailingAddress2": "string",
      "mailingAddress3": "string",
      "mailingPostalCode": "string",
      "profile": {
        "email": "string"
      }
    },
    "createdByData": {
      "userId": 0,
      "firstName": "string",
      "lastName": "string",
      "photo": "string",
      "email": "string"
    },
    "modifiedByData": {
      "userId": 0,
      "firstName": "string",
      "lastName": "string",
      "photo": "string",
      "email": "string"
    },
    "serviceList": [
      {
        "billingInvoiceServiceID": 0,
        "billingProposalID_FK": 0,
        "serviceID_FK": 0,
        "categoryId": 0,
        "title": "string",
        "startDate": "2019-08-24T14:15:22Z",
        "endDate": "2019-08-24T14:15:22Z",
        "unitCost": 0,
        "duration1": "string",
        "duration2": "string",
        "visit": 0,
        "session": 0,
        "discount": 0,
        "serviceDescription": "string",
        "categoryName": "string"
      }
    ]
  }
]
```

<h3 id="get-billing-proposal-list-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Billing Proposal List retrieved successfully|Inline|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<h3 id="get-billing-proposal-list-responseschema">Response Schema</h3>

Status Code **200**

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[[C4WX1APIFeaturesBillingProposalDtosBillingProposalDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposaldto)]|false|none|none|
|» billingProposalID|integer(int32)|false|none|none|
|» patientID_FK|integer(int32)|false|none|none|
|» proposalNumber|string|false|none|none|
|» title|string|false|none|none|
|» sendEmail|boolean¦null|false|none|none|
|» emailPatient|boolean¦null|false|none|none|
|» emailTo|string¦null|false|none|none|
|» emailCC|string¦null|false|none|none|
|» emailBCC|string¦null|false|none|none|
|» currencyID_FK|integer(int32)|false|none|none|
|» currencyCode|string|false|none|none|
|» totalCost|number(decimal)|false|none|none|
|» status|string|false|none|none|
|» groupNumber|string|false|none|none|
|» version|integer|false|none|none|
|» createdDate|string(date-time)|false|none|none|
|» createdBy_FK|integer(int32)|false|none|none|
|» modifiedDate|string(date-time)¦null|false|none|none|
|» modifiedBy_FK|integer(int32)¦null|false|none|none|
|» isDeleted|boolean|false|none|none|
|» proposalType|string|false|none|none|
|» patientData|[C4WX1APIFeaturesBillingProposalDtosBillingProposalPatientDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposalpatientdto)|false|none|none|
|»» patientID|integer(int32)|false|none|none|
|»» firstName|string|false|none|none|
|»» lastName|string|false|none|none|
|»» photo|string¦null|false|none|none|
|»» mailingAddress1|string¦null|false|none|none|
|»» mailingAddress2|string¦null|false|none|none|
|»» mailingAddress3|string¦null|false|none|none|
|»» mailingPostalCode|string¦null|false|none|none|
|»» profile|[C4WX1APIFeaturesBillingProposalDtosBillingProposalPatientProfileDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposalpatientprofiledto)¦null|false|none|none|
|»»» email|string¦null|false|none|none|
|» createdByData|[C4WX1APIFeaturesBillingProposalDtosBillingProposalUserDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposaluserdto)|false|none|none|
|»» userId|integer(int32)|false|none|none|
|»» firstName|string|false|none|none|
|»» lastName|string|false|none|none|
|»» photo|string¦null|false|none|none|
|»» email|string|false|none|none|
|» modifiedByData|[C4WX1APIFeaturesBillingProposalDtosBillingProposalUserDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposaluserdto)¦null|false|none|none|
|»» userId|integer(int32)|false|none|none|
|»» firstName|string|false|none|none|
|»» lastName|string|false|none|none|
|»» photo|string¦null|false|none|none|
|»» email|string|false|none|none|
|» serviceList|[[C4WX1APIFeaturesBillingProposalDtosBillingProposalServiceDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposalservicedto)]|false|none|none|
|»» billingInvoiceServiceID|integer(int32)|false|none|none|
|»» billingProposalID_FK|integer(int32)|false|none|none|
|»» serviceID_FK|integer(int32)|false|none|none|
|»» categoryId|integer(int32)|false|none|none|
|»» title|string|false|none|none|
|»» startDate|string(date-time)|false|none|none|
|»» endDate|string(date-time)|false|none|none|
|»» unitCost|number(decimal)|false|none|none|
|»» duration1|string¦null|false|none|none|
|»» duration2|string¦null|false|none|none|
|»» visit|integer(int32)|false|none|none|
|»» session|integer(int32)|false|none|none|
|»» discount|number(decimal)|false|none|none|
|»» serviceDescription|string¦null|false|none|none|
|»» categoryName|string|false|none|none|

<aside class="success">
This operation does not require authentication
</aside>

## Create Billing Proposal

<a id="opIdC4WX1APIFeaturesBillingProposalCreateCreate"></a>

> Code samples

```shell
# You can also use wget
curl -X POST https://localhost:7055/api/billing-proposal \
  -H 'Content-Type: */*' \
  -H 'Accept: application/problem+json'

```

```http
POST https://localhost:7055/api/billing-proposal HTTP/1.1
Host: localhost:7055
Content-Type: */*
Accept: application/problem+json

```

```javascript
const inputBody = '{
  "patientID_FK": 1,
  "title": "Title",
  "sendEmail": true,
  "emailPatient": true,
  "emailTo": "test-to@gmail.com",
  "emailCC": "test-cc@gmail.com",
  "emailBCC": "test-bcc@gmail.com",
  "currencyID_FK": 1,
  "status": "Active",
  "groupNumber": "1",
  "version": 1,
  "proposalType": "ProposalType",
  "userId": 1,
  "serviceList": [
    {
      "billingInvoiceServiceID": 0,
      "billingProposalID_FK": 0,
      "serviceID_FK": 1,
      "categoryId": 0,
      "title": null,
      "startDate": "2025-02-21T20:43:16.8364914+08:00",
      "endDate": "2025-02-21T20:43:16.8364935+08:00",
      "unitCost": 0,
      "duration1": "Duration1",
      "duration2": "Duration2",
      "visit": 1,
      "session": 0,
      "discount": 0,
      "serviceDescription": "ServiceDescription",
      "categoryName": null
    }
  ]
}';
const headers = {
  'Content-Type':'*/*',
  'Accept':'application/problem+json'
};

fetch('https://localhost:7055/api/billing-proposal',
{
  method: 'POST',
  body: inputBody,
  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```python
import requests
headers = {
  'Content-Type': '*/*',
  'Accept': 'application/problem+json'
}

r = requests.post('https://localhost:7055/api/billing-proposal', headers = headers)

print(r.json())

```

`POST /api/billing-proposal`

Create new Billing Proposal

> Body parameter

<h3 id="create-billing-proposal-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[C4WX1APIFeaturesBillingProposalDtosCreateBillingProposalDto](#schemac4wx1apifeaturesbillingproposaldtoscreatebillingproposaldto)|true|none|

> Example responses

> 500 Response

```json
{
  "status": "Internal Server Error!",
  "code": 500,
  "reason": "Something unexpected has happened",
  "note": "See application log for stack trace."
}
```

<h3 id="create-billing-proposal-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|204|[No Content](https://tools.ietf.org/html/rfc7231#section-6.3.5)|No Content|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## Get Billing Proposal Session Balance

<a id="opIdC4WX1APIFeaturesBillingProposalGetGetSessionBalance"></a>

> Code samples

```shell
# You can also use wget
curl -X GET https://localhost:7055/api/billing-proposal/session-balance?proposalId=0&serviceId=0&endDate=2019-08-24T14%3A15%3A22Z \
  -H 'Accept: application/json'

```

```http
GET https://localhost:7055/api/billing-proposal/session-balance?proposalId=0&serviceId=0&endDate=2019-08-24T14%3A15%3A22Z HTTP/1.1
Host: localhost:7055
Accept: application/json

```

```javascript

const headers = {
  'Accept':'application/json'
};

fetch('https://localhost:7055/api/billing-proposal/session-balance?proposalId=0&serviceId=0&endDate=2019-08-24T14%3A15%3A22Z',
{
  method: 'GET',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```python
import requests
headers = {
  'Accept': 'application/json'
}

r = requests.get('https://localhost:7055/api/billing-proposal/session-balance', params={
  'proposalId': '0',  'serviceId': '0',  'endDate': '2019-08-24T14:15:22Z'
}, headers = headers)

print(r.json())

```

`GET /api/billing-proposal/session-balance`

Get Billing Proposal Session Balance by its ProposalId, ServiceId and EndDate

<h3 id="get-billing-proposal-session-balance-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|proposalId|query|integer(int32)|true|none|
|serviceId|query|integer(int32)|true|none|
|endDate|query|string(date-time)|true|none|

> Example responses

> 200 Response

```json
"string"
```

<h3 id="get-billing-proposal-session-balance-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Billing Proposal Session Balance retrieved successfully|string|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

<h1 id="c4wx1-api-billing-invoice">Billing-Invoice</h1>

## Get Billing Invoice

<a id="opIdC4WX1APIFeaturesBillingInvoiceGetGet"></a>

> Code samples

```shell
# You can also use wget
curl -X GET https://localhost:7055/api/billing-invoice/{id} \
  -H 'Accept: application/json'

```

```http
GET https://localhost:7055/api/billing-invoice/{id} HTTP/1.1
Host: localhost:7055
Accept: application/json

```

```javascript

const headers = {
  'Accept':'application/json'
};

fetch('https://localhost:7055/api/billing-invoice/{id}',
{
  method: 'GET',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```python
import requests
headers = {
  'Accept': 'application/json'
}

r = requests.get('https://localhost:7055/api/billing-invoice/{id}', headers = headers)

print(r.json())

```

`GET /api/billing-invoice/{id}`

Get Billing Invoice by its ID

<h3 id="get-billing-invoice-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|integer(int32)|true|none|
|initialCareAssessmentID|query|integer(int32)|false|none|
|careReportID|query|integer(int32)|false|none|
|patientID|query|integer(int32)|false|none|

> Example responses

> 200 Response

```json
{
  "billingInvoiceID": 0,
  "patientID_FK": 0,
  "invoiceNumber": "string",
  "invoiceDueDate": "2019-08-24T14:15:22Z",
  "caseNumber": "string",
  "initialCareAssessmentID_FK": 0,
  "careReportID_FK": 0,
  "consumable": true,
  "sendEmail": true,
  "emailPatient": true,
  "emailTo": "string",
  "emailCC": "string",
  "emailBCC": "string",
  "currencyID_FK": 0,
  "totalCost": 0,
  "status": "string",
  "groupNumber": "string",
  "version": 0,
  "createdDate": "2019-08-24T14:15:22Z",
  "createdBy_FK": 0,
  "modifiedDate": "2019-08-24T14:15:22Z",
  "modifiedBy_FK": 0,
  "isDeleted": true,
  "invoiceDate": "2019-08-24T14:15:22Z",
  "currencyCode": "string",
  "patientData": {
    "patientID": 0,
    "firstName": "string",
    "lastName": "string",
    "photo": "string",
    "caseID": "string",
    "profile": {
      "email": "string",
      "billingAddress1": "string",
      "billingAddress2": "string",
      "billingAddress3": "string",
      "billingPostalCode": "string"
    }
  },
  "createdByData": {
    "userId": 0,
    "firstName": "string",
    "lastName": "string",
    "photo": "string",
    "email": "string"
  },
  "modifiedByData": {
    "userId": 0,
    "firstName": "string",
    "lastName": "string",
    "photo": "string",
    "email": "string"
  },
  "serviceList": [
    {
      "billingInvoiceServiceID": 0,
      "proposalID_FK": 0,
      "serviceID_FK": 0,
      "unitCost": 0,
      "session": 0,
      "discount": 0,
      "title": "string",
      "categoryName": "string",
      "billingProposalData": {
        "billingProposalID": 0,
        "proposalNumber": "string",
        "patientID_FK": 0,
        "title": "string",
        "proposalType": "string"
      }
    }
  ],
  "consumableList": [
    {
      "billingInvoiceConsumableID": 0,
      "itemID_FK": 0,
      "unitPrice": 0,
      "quantity": 0,
      "billingInvoiceItemDto": {
        "itemID": 0,
        "categoryID_FK": 0,
        "categoryName": "string",
        "itemName": "string"
      }
    }
  ]
}
```

<h3 id="get-billing-invoice-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Billing Invoice retrieved successfully|[C4WX1APIFeaturesBillingInvoiceDtosBillingInvoiceDto](#schemac4wx1apifeaturesbillinginvoicedtosbillinginvoicedto)|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Billing Invoice not found|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

<h1 id="c4wx1-api-audit-enquiry">Audit-Enquiry</h1>

## Get Audit Enquiry

<a id="opIdC4WX1APIFeaturesAuditEnquiryGetGet"></a>

> Code samples

```shell
# You can also use wget
curl -X GET https://localhost:7055/api/audit-enquiry/{id} \
  -H 'Accept: application/json'

```

```http
GET https://localhost:7055/api/audit-enquiry/{id} HTTP/1.1
Host: localhost:7055
Accept: application/json

```

```javascript

const headers = {
  'Accept':'application/json'
};

fetch('https://localhost:7055/api/audit-enquiry/{id}',
{
  method: 'GET',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```python
import requests
headers = {
  'Accept': 'application/json'
}

r = requests.get('https://localhost:7055/api/audit-enquiry/{id}', headers = headers)

print(r.json())

```

`GET /api/audit-enquiry/{id}`

Get Audit Enquiry by its ID

<h3 id="get-audit-enquiry-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|integer(int32)|true|none|

> Example responses

> 200 Response

```json
{
  "auditAction": "string",
  "actionTime": "2019-08-24T14:15:22Z",
  "enquiryID": 0,
  "careManagerAssignedID_FK": 0,
  "enquirySourceID_FK": 0,
  "firstName": "string",
  "lastName": "string",
  "dateOfBirth": "2019-08-24T14:15:22Z",
  "raceID_FK": 0,
  "identificationNumber": "string",
  "preferredLanguageID_FK": 0,
  "genderID_FK": 0,
  "patientAddress1": "string",
  "patientAddress2": "string",
  "patientAddress3": "string",
  "postalCode": "string",
  "nameOfCaller": "string",
  "contactNumberOfCaller": "string",
  "emailOfCaller": "string",
  "preferredAppointmentDateTime": "2019-08-24T14:15:22Z",
  "medicalHistory": "string",
  "caregiverAtHomeID_FK": 0,
  "servicesRequiredID_FK": 0,
  "status": "string",
  "remarks": "string",
  "createdDate": "2019-08-24T14:15:22Z",
  "createdBy_FK": 0,
  "modifiedDate": "2019-08-24T14:15:22Z",
  "modifiedBy_FK": 0,
  "isDeleted": true,
  "otherRace": "string",
  "otherPreferredLanguage": "string",
  "userOrganizationID_FK": 0,
  "caseNumber": "string",
  "note": "string",
  "orderID": "string",
  "modifiedBy": {
    "userId": 0,
    "firstName": "string",
    "lastName": "string",
    "photo": "string"
  },
  "createdBy": {
    "userId": 0,
    "firstName": "string",
    "lastName": "string",
    "photo": "string"
  }
}
```

<h3 id="get-audit-enquiry-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Audit Enquiry retrieved successfully|[C4WX1APIFeaturesAuditEnquiryDtosAuditEnquiryDto](#schemac4wx1apifeaturesauditenquirydtosauditenquirydto)|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Audit Enquiry not found|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

<h1 id="c4wx1-api-api-access-key">Api-Access-Key</h1>

## Get APIAccessKey

<a id="opIdC4WX1APIFeaturesAPIAccessKeyGetGet"></a>

> Code samples

```shell
# You can also use wget
curl -X GET https://localhost:7055/api/api-access-key/{id} \
  -H 'Accept: application/json'

```

```http
GET https://localhost:7055/api/api-access-key/{id} HTTP/1.1
Host: localhost:7055
Accept: application/json

```

```javascript

const headers = {
  'Accept':'application/json'
};

fetch('https://localhost:7055/api/api-access-key/{id}',
{
  method: 'GET',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```python
import requests
headers = {
  'Accept': 'application/json'
}

r = requests.get('https://localhost:7055/api/api-access-key/{id}', headers = headers)

print(r.json())

```

`GET /api/api-access-key/{id}`

Get APIAccessKey by its ID or Access Key

<h3 id="get-apiaccesskey-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|integer(int32)|true|none|
|accessKey|query|string|false|none|

> Example responses

> 200 Response

```json
{
  "apiAccessKeyID": 0,
  "tokenCode": "string",
  "accessKey": "string",
  "expiryDate": "2019-08-24T14:15:22Z",
  "createdDate": "2019-08-24T14:15:22Z",
  "updatedDate": "2019-08-24T14:15:22Z",
  "userId_FK": 0
}
```

<h3 id="get-apiaccesskey-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|APIAccessKey retrieved successfully|[C4WX1APIFeaturesAPIAccessKeyDtosAPIAccessKeyDto](#schemac4wx1apifeaturesapiaccesskeydtosapiaccesskeydto)|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|APIAccessKey not found|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## Create APIAccessKey

<a id="opIdC4WX1APIFeaturesAPIAccessKeyCreateCreate"></a>

> Code samples

```shell
# You can also use wget
curl -X POST https://localhost:7055/api/api-access-key \
  -H 'Content-Type: */*' \
  -H 'Accept: application/json'

```

```http
POST https://localhost:7055/api/api-access-key HTTP/1.1
Host: localhost:7055
Content-Type: */*
Accept: application/json

```

```javascript
const inputBody = '{
  "code": "string",
  "userId": 0
}';
const headers = {
  'Content-Type':'*/*',
  'Accept':'application/json'
};

fetch('https://localhost:7055/api/api-access-key',
{
  method: 'POST',
  body: inputBody,
  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```python
import requests
headers = {
  'Content-Type': '*/*',
  'Accept': 'application/json'
}

r = requests.post('https://localhost:7055/api/api-access-key', headers = headers)

print(r.json())

```

`POST /api/api-access-key`

Create a new APIAccessKey

> Body parameter

<h3 id="create-apiaccesskey-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[C4WX1APIFeaturesAPIAccessKeyDtosCreateAPIAccessKeyDto](#schemac4wx1apifeaturesapiaccesskeydtoscreateapiaccesskeydto)|true|none|

> Example responses

> 200 Response

```json
{
  "apiAccessKeyID": 0,
  "tokenCode": "string",
  "accessKey": "string",
  "expiryDate": "2019-08-24T14:15:22Z",
  "createdDate": "2019-08-24T14:15:22Z",
  "updatedDate": "2019-08-24T14:15:22Z",
  "userId_FK": 0
}
```

<h3 id="create-apiaccesskey-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|APIAccessKey created successfully|[C4WX1APIFeaturesAPIAccessKeyDtosAPIAccessKeyDto](#schemac4wx1apifeaturesapiaccesskeydtosapiaccesskeydto)|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|APIAccessKey not found|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

<h1 id="c4wx1-api-activity">Activity</h1>

## Update Activity

<a id="opIdC4WX1APIFeaturesActivityUpdateUpdate"></a>

> Code samples

```shell
# You can also use wget
curl -X PUT https://localhost:7055/api/activity/{activityID} \
  -H 'Content-Type: */*' \
  -H 'Accept: application/problem+json'

```

```http
PUT https://localhost:7055/api/activity/{activityID} HTTP/1.1
Host: localhost:7055
Content-Type: */*
Accept: application/problem+json

```

```javascript
const inputBody = '{
  "problemListID_FK": 1,
  "diseaseID_FK": 1,
  "activityDetail": "Activity Detail",
  "diseaseSubInfoID_FK": 1,
  "userId": 1
}';
const headers = {
  'Content-Type':'*/*',
  'Accept':'application/problem+json'
};

fetch('https://localhost:7055/api/activity/{activityID}',
{
  method: 'PUT',
  body: inputBody,
  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```python
import requests
headers = {
  'Content-Type': '*/*',
  'Accept': 'application/problem+json'
}

r = requests.put('https://localhost:7055/api/activity/{activityID}', headers = headers)

print(r.json())

```

`PUT /api/activity/{activityID}`

Update an existing Activity

> Body parameter

<h3 id="update-activity-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|activityID|path|integer(int32)|true|none|
|body|body|[C4WX1APIFeaturesActivityDtosUpdateActivityDto](#schemac4wx1apifeaturesactivitydtosupdateactivitydto)|true|none|

> Example responses

> 500 Response

```json
{
  "status": "Internal Server Error!",
  "code": 500,
  "reason": "Something unexpected has happened",
  "note": "See application log for stack trace."
}
```

<h3 id="update-activity-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|204|[No Content](https://tools.ietf.org/html/rfc7231#section-6.3.5)|Activity updated successfully|None|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Activity not found|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## Delete Activity

<a id="opIdC4WX1APIFeaturesActivityDeleteDelete"></a>

> Code samples

```shell
# You can also use wget
curl -X DELETE https://localhost:7055/api/activity/{activityID} \
  -H 'Content-Type: */*' \
  -H 'Accept: application/problem+json'

```

```http
DELETE https://localhost:7055/api/activity/{activityID} HTTP/1.1
Host: localhost:7055
Content-Type: */*
Accept: application/problem+json

```

```javascript
const inputBody = '{
  "userID": 1
}';
const headers = {
  'Content-Type':'*/*',
  'Accept':'application/problem+json'
};

fetch('https://localhost:7055/api/activity/{activityID}',
{
  method: 'DELETE',
  body: inputBody,
  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```python
import requests
headers = {
  'Content-Type': '*/*',
  'Accept': 'application/problem+json'
}

r = requests.delete('https://localhost:7055/api/activity/{activityID}', headers = headers)

print(r.json())

```

`DELETE /api/activity/{activityID}`

Delete an existing Activity

> Body parameter

<h3 id="delete-activity-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|activityID|path|integer(int32)|true|none|
|body|body|[C4WX1APIFeaturesActivityDtosDeleteActivityDto](#schemac4wx1apifeaturesactivitydtosdeleteactivitydto)|true|none|

> Example responses

> 500 Response

```json
{
  "status": "Internal Server Error!",
  "code": 500,
  "reason": "Something unexpected has happened",
  "note": "See application log for stack trace."
}
```

<h3 id="delete-activity-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|204|[No Content](https://tools.ietf.org/html/rfc7231#section-6.3.5)|Activity deleted successfully|None|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Activity not found|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## Get Activity

<a id="opIdC4WX1APIFeaturesActivityGetGetById"></a>

> Code samples

```shell
# You can also use wget
curl -X GET https://localhost:7055/api/activity/{id} \
  -H 'Accept: application/problem+json'

```

```http
GET https://localhost:7055/api/activity/{id} HTTP/1.1
Host: localhost:7055
Accept: application/problem+json

```

```javascript

const headers = {
  'Accept':'application/problem+json'
};

fetch('https://localhost:7055/api/activity/{id}',
{
  method: 'GET',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```python
import requests
headers = {
  'Accept': 'application/problem+json'
}

r = requests.get('https://localhost:7055/api/activity/{id}', headers = headers)

print(r.json())

```

`GET /api/activity/{id}`

Get an Activity by its ID

<h3 id="get-activity-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|integer(int32)|true|none|

> Example responses

> 500 Response

```json
{
  "status": "Internal Server Error!",
  "code": 500,
  "reason": "Something unexpected has happened",
  "note": "See application log for stack trace."
}
```

<h3 id="get-activity-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Activity retrieved successfully|None|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Activity not found|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## Get Activity Count

<a id="opIdC4WX1APIFeaturesActivityGetGetCount"></a>

> Code samples

```shell
# You can also use wget
curl -X GET https://localhost:7055/api/activity/count \
  -H 'Accept: application/json'

```

```http
GET https://localhost:7055/api/activity/count HTTP/1.1
Host: localhost:7055
Accept: application/json

```

```javascript

const headers = {
  'Accept':'application/json'
};

fetch('https://localhost:7055/api/activity/count',
{
  method: 'GET',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```python
import requests
headers = {
  'Accept': 'application/json'
}

r = requests.get('https://localhost:7055/api/activity/count', headers = headers)

print(r.json())

```

`GET /api/activity/count`

Get the number of activities

> Example responses

> 200 Response

```json
0
```

<h3 id="get-activity-count-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Number of activities retrieved successfully|integer|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## Get Activity List

<a id="opIdC4WX1APIFeaturesActivityGetGetList"></a>

> Code samples

```shell
# You can also use wget
curl -X GET https://localhost:7055/api/activity \
  -H 'Accept: application/json'

```

```http
GET https://localhost:7055/api/activity HTTP/1.1
Host: localhost:7055
Accept: application/json

```

```javascript

const headers = {
  'Accept':'application/json'
};

fetch('https://localhost:7055/api/activity',
{
  method: 'GET',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```python
import requests
headers = {
  'Accept': 'application/json'
}

r = requests.get('https://localhost:7055/api/activity', headers = headers)

print(r.json())

```

`GET /api/activity`

Get a list of activities

<h3 id="get-activity-list-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|pageIndex|query|integer(int32)|false|none|
|pageSize|query|integer(int32)|false|none|
|orderBy|query|string|false|none|

> Example responses

> 200 Response

```json
[
  {
    "activityID": 0,
    "problemListID_FK": 0,
    "diseaseID_FK": 0,
    "activityDetail": "string",
    "isDeleted": true,
    "createdDate": "2019-08-24T14:15:22Z",
    "createdBy_FK": 0,
    "modifiedDate": "2019-08-24T14:15:22Z",
    "modifiedBy_FK": 0,
    "diseaseSubInfoID_FK": 0,
    "canDelete": true
  }
]
```

<h3 id="get-activity-list-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Activity list retrieved successfully|Inline|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[FastEndpointsInternalErrorResponse](#schemafastendpointsinternalerrorresponse)|

<h3 id="get-activity-list-responseschema">Response Schema</h3>

Status Code **200**

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[[C4WX1APIFeaturesActivityDtosActivityDto](#schemac4wx1apifeaturesactivitydtosactivitydto)]|false|none|none|
|» activityID|integer(int32)|false|none|none|
|» problemListID_FK|integer(int32)|false|none|none|
|» diseaseID_FK|integer(int32)|false|none|none|
|» activityDetail|string|false|none|none|
|» isDeleted|boolean|false|none|none|
|» createdDate|string(date-time)¦null|false|none|none|
|» createdBy_FK|integer(int32)¦null|false|none|none|
|» modifiedDate|string(date-time)¦null|false|none|none|
|» modifiedBy_FK|integer(int32)¦null|false|none|none|
|» diseaseSubInfoID_FK|integer(int32)¦null|false|none|none|
|» canDelete|boolean|false|none|none|

<aside class="success">
This operation does not require authentication
</aside>

## Create Activity

<a id="opIdC4WX1APIFeaturesActivityCreateCreate"></a>

> Code samples

```shell
# You can also use wget
curl -X POST https://localhost:7055/api/activity \
  -H 'Content-Type: */*' \
  -H 'Accept: application/problem+json'

```

```http
POST https://localhost:7055/api/activity HTTP/1.1
Host: localhost:7055
Content-Type: */*
Accept: application/problem+json

```

```javascript
const inputBody = '{
  "problemListID_FK": 1,
  "diseaseID_FK": 1,
  "activityDetail": "Activity Detail",
  "diseaseSubInfoID_FK": 1,
  "userId": 1
}';
const headers = {
  'Content-Type':'*/*',
  'Accept':'application/problem+json'
};

fetch('https://localhost:7055/api/activity',
{
  method: 'POST',
  body: inputBody,
  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```python
import requests
headers = {
  'Content-Type': '*/*',
  'Accept': 'application/problem+json'
}

r = requests.post('https://localhost:7055/api/activity', headers = headers)

print(r.json())

```

`POST /api/activity`

Create a new Activity

> Body parameter

<h3 id="create-activity-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[C4WX1APIFeaturesActivityDtosCreateActivityDto](#schemac4wx1apifeaturesactivitydtoscreateactivitydto)|true|none|

> Example responses

> 500 Response

```json
{
  "status": "Internal Server Error!",
  "code": 500,
  "reason": "Something unexpected has happened",
  "note": "See application log for stack trace."
}
```

<h3 id="create-activity-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|204|[No Content](https://tools.ietf.org/html/rfc7231#section-6.3.5)|Activity created successfully|None|
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
  "status": "Internal Server Error!",
  "code": 500,
  "reason": "Something unexpected has happened",
  "note": "See application log for stack trace."
}

```

the dto used to send an error response to the client when an unhandled exception occurs on the server

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|status|string|false|none|error status|
|code|integer(int32)|false|none|http status code of the error response|
|reason|string|false|none|the reason for the error|
|note|string|false|none|additional information or instructions|

<h2 id="tocS_C4WX1APIFeaturesSysConfigDtosUpdateSysConfigDto">C4WX1APIFeaturesSysConfigDtosUpdateSysConfigDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturessysconfigdtosupdatesysconfigdto"></a>
<a id="schema_C4WX1APIFeaturesSysConfigDtosUpdateSysConfigDto"></a>
<a id="tocSc4wx1apifeaturessysconfigdtosupdatesysconfigdto"></a>
<a id="tocsc4wx1apifeaturessysconfigdtosupdatesysconfigdto"></a>

```json
{
  "configName": "string",
  "configValue": "string",
  "userID": 0
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|configName|string|false|none|none|
|configValue|string|false|none|none|
|userID|integer(int32)|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesSysConfigDtosSysConfigDto">C4WX1APIFeaturesSysConfigDtosSysConfigDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturessysconfigdtossysconfigdto"></a>
<a id="schema_C4WX1APIFeaturesSysConfigDtosSysConfigDto"></a>
<a id="tocSc4wx1apifeaturessysconfigdtossysconfigdto"></a>
<a id="tocsc4wx1apifeaturessysconfigdtossysconfigdto"></a>

```json
{
  "configName": "string",
  "configValue": "string",
  "modifiedDate": "2019-08-24T14:15:22Z",
  "modifiedBy_FK": 0,
  "isConfigurable": true,
  "description": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|configName|string|false|none|none|
|configValue|string¦null|false|none|none|
|modifiedDate|string(date-time)¦null|false|none|none|
|modifiedBy_FK|integer(int32)¦null|false|none|none|
|isConfigurable|boolean¦null|false|none|none|
|description|string¦null|false|none|none|

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
  "configName": "Config Name",
  "configValue": "Config Value",
  "isConfigurable": false,
  "description": "Description"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|configName|string|false|none|none|
|configValue|string¦null|false|none|none|
|isConfigurable|boolean¦null|false|none|none|
|description|string¦null|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesChatDtosChatDto">C4WX1APIFeaturesChatDtosChatDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeatureschatdtoschatdto"></a>
<a id="schema_C4WX1APIFeaturesChatDtosChatDto"></a>
<a id="tocSc4wx1apifeatureschatdtoschatdto"></a>
<a id="tocsc4wx1apifeatureschatdtoschatdto"></a>

```json
{
  "chatID": 0,
  "comment": "string",
  "attachment": "string",
  "attachment_Physical": "string",
  "parentID_FK": 0,
  "patientID_FK": 0,
  "createdDate": "2019-08-24T14:15:22Z",
  "createdBy_FK": 0,
  "isDeleted": true,
  "family": true,
  "userData": {
    "userId": 0,
    "firstname": "string",
    "lastname": "string",
    "photo": "string"
  },
  "patientData": {
    "patientID": 0,
    "firstname": "string",
    "lastname": "string",
    "photo": "string"
  },
  "commentList": [
    {
      "chatID": 0,
      "comment": "string",
      "attachment": "string",
      "attachment_Physical": "string",
      "parentID_FK": 0,
      "patientID_FK": 0,
      "createdDate": "2019-08-24T14:15:22Z",
      "createdBy_FK": 0,
      "isDeleted": true,
      "family": true,
      "userData": {
        "userId": 0,
        "firstname": "string",
        "lastname": "string",
        "photo": "string"
      },
      "patientData": {
        "patientID": 0,
        "firstname": "string",
        "lastname": "string",
        "photo": "string"
      },
      "commentList": []
    }
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|chatID|integer(int32)|false|none|none|
|comment|string¦null|false|none|none|
|attachment|string¦null|false|none|none|
|attachment_Physical|string¦null|false|none|none|
|parentID_FK|integer(int32)¦null|false|none|none|
|patientID_FK|integer(int32)¦null|false|none|none|
|createdDate|string(date-time)|false|none|none|
|createdBy_FK|integer(int32)|false|none|none|
|isDeleted|boolean|false|none|none|
|family|boolean¦null|false|none|none|
|userData|[C4WX1APIFeaturesChatDtosChatUserDto](#schemac4wx1apifeatureschatdtoschatuserdto)¦null|false|none|none|
|patientData|[C4WX1APIFeaturesChatDtosChatPatientDto](#schemac4wx1apifeatureschatdtoschatpatientdto)¦null|false|none|none|
|commentList|[[C4WX1APIFeaturesChatDtosChatDto](#schemac4wx1apifeatureschatdtoschatdto)]|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesChatDtosChatUserDto">C4WX1APIFeaturesChatDtosChatUserDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeatureschatdtoschatuserdto"></a>
<a id="schema_C4WX1APIFeaturesChatDtosChatUserDto"></a>
<a id="tocSc4wx1apifeatureschatdtoschatuserdto"></a>
<a id="tocsc4wx1apifeatureschatdtoschatuserdto"></a>

```json
{
  "userId": 0,
  "firstname": "string",
  "lastname": "string",
  "photo": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|userId|integer(int32)|false|none|none|
|firstname|string|false|none|none|
|lastname|string|false|none|none|
|photo|string¦null|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesChatDtosChatPatientDto">C4WX1APIFeaturesChatDtosChatPatientDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeatureschatdtoschatpatientdto"></a>
<a id="schema_C4WX1APIFeaturesChatDtosChatPatientDto"></a>
<a id="tocSc4wx1apifeatureschatdtoschatpatientdto"></a>
<a id="tocsc4wx1apifeatureschatdtoschatpatientdto"></a>

```json
{
  "patientID": 0,
  "firstname": "string",
  "lastname": "string",
  "photo": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|patientID|integer(int32)|false|none|none|
|firstname|string|false|none|none|
|lastname|string|false|none|none|
|photo|string¦null|false|none|none|

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

<h2 id="tocS_C4WX1APIFeaturesChatDtosDeleteChatDto">C4WX1APIFeaturesChatDtosDeleteChatDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeatureschatdtosdeletechatdto"></a>
<a id="schema_C4WX1APIFeaturesChatDtosDeleteChatDto"></a>
<a id="tocSc4wx1apifeatureschatdtosdeletechatdto"></a>
<a id="tocsc4wx1apifeatureschatdtosdeletechatdto"></a>

```json
{
  "userID": 1
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|userID|integer(int32)|false|none|none|

<h2 id="tocS_FastEndpointsErrorResponse">FastEndpointsErrorResponse</h2>
<!-- backwards compatibility -->
<a id="schemafastendpointserrorresponse"></a>
<a id="schema_FastEndpointsErrorResponse"></a>
<a id="tocSfastendpointserrorresponse"></a>
<a id="tocsfastendpointserrorresponse"></a>

```json
{
  "statusCode": 400,
  "message": "One or more errors occurred!",
  "errors": {
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
|statusCode|integer(int32)|false|none|the http status code sent to the client. default is 400.|
|message|string|false|none|the message for the error response|
|errors|object|false|none|the collection of errors for the current context|
|» **additionalProperties**|[string]|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesChatDtosCreateChatDto">C4WX1APIFeaturesChatDtosCreateChatDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeatureschatdtoscreatechatdto"></a>
<a id="schema_C4WX1APIFeaturesChatDtosCreateChatDto"></a>
<a id="tocSc4wx1apifeatureschatdtoscreatechatdto"></a>
<a id="tocsc4wx1apifeatureschatdtoscreatechatdto"></a>

```json
{
  "attachment": "Attachment",
  "attachment_Physical": "Attachment_Physical",
  "createdBy_FK": 1,
  "parentID_FK": 1,
  "patientID_FK": 1,
  "comment": "Comment",
  "family": true
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|attachment|string¦null|false|none|none|
|attachment_Physical|string¦null|false|none|none|
|createdBy_FK|integer(int32)|false|none|none|
|parentID_FK|integer(int32)¦null|false|none|none|
|patientID_FK|integer(int32)¦null|false|none|none|
|comment|string¦null|false|none|none|
|family|boolean¦null|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesC4WImageDtosUpdateC4WImageDto">C4WX1APIFeaturesC4WImageDtosUpdateC4WImageDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesc4wimagedtosupdatec4wimagedto"></a>
<a id="schema_C4WX1APIFeaturesC4WImageDtosUpdateC4WImageDto"></a>
<a id="tocSc4wx1apifeaturesc4wimagedtosupdatec4wimagedto"></a>
<a id="tocsc4wx1apifeaturesc4wimagedtosupdatec4wimagedto"></a>

```json
{
  "woundImageName": "wound image name",
  "woundImageData": "wound image data",
  "woundBedImageName": "wound bed image name",
  "woundBedImageData": "wound bed image data",
  "tissueImageName": "tissue image name",
  "tissueImageData": "tissue image data",
  "depthImageName": "depth image name",
  "depthImageData": "depth image data",
  "userId": 1
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|woundImageName|string¦null|false|none|none|
|woundImageData|string¦null|false|none|none|
|woundBedImageName|string¦null|false|none|none|
|woundBedImageData|string¦null|false|none|none|
|tissueImageName|string¦null|false|none|none|
|tissueImageData|string¦null|false|none|none|
|depthImageName|string¦null|false|none|none|
|depthImageData|string¦null|false|none|none|
|userId|integer(int32)|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesC4WImageDtosC4WImageDto">C4WX1APIFeaturesC4WImageDtosC4WImageDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesc4wimagedtosc4wimagedto"></a>
<a id="schema_C4WX1APIFeaturesC4WImageDtosC4WImageDto"></a>
<a id="tocSc4wx1apifeaturesc4wimagedtosc4wimagedto"></a>
<a id="tocsc4wx1apifeaturesc4wimagedtosc4wimagedto"></a>

```json
{
  "c4WImageId": 0,
  "woundImageName": "string",
  "woundImageData": "string",
  "woundBedImageName": "string",
  "woundBedImageData": "string",
  "tissueImageName": "string",
  "tissueImageData": "string",
  "depthImageName": "string",
  "depthImageData": "string",
  "isDeleted": true,
  "createdDate": "2019-08-24T14:15:22Z",
  "createdBy_FK": 0,
  "modifiedDate": "2019-08-24T14:15:22Z"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|c4WImageId|integer(int32)|false|none|none|
|woundImageName|string¦null|false|none|none|
|woundImageData|string¦null|false|none|none|
|woundBedImageName|string¦null|false|none|none|
|woundBedImageData|string¦null|false|none|none|
|tissueImageName|string¦null|false|none|none|
|tissueImageData|string¦null|false|none|none|
|depthImageName|string¦null|false|none|none|
|depthImageData|string¦null|false|none|none|
|isDeleted|boolean|false|none|none|
|createdDate|string(date-time)|false|none|none|
|createdBy_FK|integer(int32)|false|none|none|
|modifiedDate|string(date-time)¦null|false|none|none|

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
  "woundImageName": "wound image name",
  "woundImageData": "wound image data",
  "woundBedImageName": "wound bed image name",
  "woundBedImageData": "wound bed image data",
  "tissueImageName": "tissue image name",
  "tissueImageData": "tissue image data",
  "depthImageName": "depth image name",
  "depthImageData": "depth image data",
  "userId": 1
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|woundImageName|string¦null|false|none|none|
|woundImageData|string¦null|false|none|none|
|woundBedImageName|string¦null|false|none|none|
|woundBedImageData|string¦null|false|none|none|
|tissueImageName|string¦null|false|none|none|
|tissueImageData|string¦null|false|none|none|
|depthImageName|string¦null|false|none|none|
|depthImageData|string¦null|false|none|none|
|userId|integer(int32)|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesC4WDeviceTokenDtosUpdateC4WDeviceTokenDto">C4WX1APIFeaturesC4WDeviceTokenDtosUpdateC4WDeviceTokenDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesc4wdevicetokendtosupdatec4wdevicetokendto"></a>
<a id="schema_C4WX1APIFeaturesC4WDeviceTokenDtosUpdateC4WDeviceTokenDto"></a>
<a id="tocSc4wx1apifeaturesc4wdevicetokendtosupdatec4wdevicetokendto"></a>
<a id="tocsc4wx1apifeaturesc4wdevicetokendtosupdatec4wdevicetokendto"></a>

```json
{
  "oldDeviceToken": "Old token",
  "newDeviceToken": "New token",
  "clientEnvironment": "test env",
  "device": "IPhone",
  "userId": 1
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|oldDeviceToken|string¦null|false|none|none|
|newDeviceToken|string¦null|false|none|none|
|clientEnvironment|string¦null|false|none|none|
|device|string¦null|false|none|none|
|userId|integer(int32)|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesC4WDeviceTokenDtosC4WDeviceTokenDto">C4WX1APIFeaturesC4WDeviceTokenDtosC4WDeviceTokenDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesc4wdevicetokendtosc4wdevicetokendto"></a>
<a id="schema_C4WX1APIFeaturesC4WDeviceTokenDtosC4WDeviceTokenDto"></a>
<a id="tocSc4wx1apifeaturesc4wdevicetokendtosc4wdevicetokendto"></a>
<a id="tocsc4wx1apifeaturesc4wdevicetokendtosc4wdevicetokendto"></a>

```json
{
  "c4WDeviceTokenId": 0,
  "oldDeviceToken": "string",
  "newDeviceToken": "string",
  "clientEnvironment": "string",
  "device": "string",
  "isDeleted": true,
  "createdDate": "2019-08-24T14:15:22Z",
  "createdBy_FK": 0,
  "modifiedDate": "2019-08-24T14:15:22Z",
  "modifiedBy_FK": 0
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|c4WDeviceTokenId|integer(int32)|false|none|none|
|oldDeviceToken|string¦null|false|none|none|
|newDeviceToken|string¦null|false|none|none|
|clientEnvironment|string¦null|false|none|none|
|device|string¦null|false|none|none|
|isDeleted|boolean|false|none|none|
|createdDate|string(date-time)|false|none|none|
|createdBy_FK|integer(int32)|false|none|none|
|modifiedDate|string(date-time)¦null|false|none|none|
|modifiedBy_FK|integer(int32)¦null|false|none|none|

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
  "oldDeviceToken": "Old Token",
  "newDeviceToken": "New Token",
  "clientEnvironment": "test env",
  "device": "Iphone",
  "userId": 1
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|oldDeviceToken|string¦null|false|none|none|
|newDeviceToken|string¦null|false|none|none|
|clientEnvironment|string¦null|false|none|none|
|device|string¦null|false|none|none|
|userId|integer(int32)|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesBranchDtosUpdateBranchDto">C4WX1APIFeaturesBranchDtosUpdateBranchDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesbranchdtosupdatebranchdto"></a>
<a id="schema_C4WX1APIFeaturesBranchDtosUpdateBranchDto"></a>
<a id="tocSc4wx1apifeaturesbranchdtosupdatebranchdto"></a>
<a id="tocsc4wx1apifeaturesbranchdtosupdatebranchdto"></a>

```json
{
  "branchName": "BranchName",
  "address1": "Address1",
  "address2": "Address2",
  "address3": "Address3",
  "contact": "Contact",
  "email": "test@test.com",
  "status": "Active",
  "currencyID_FK": 1,
  "userId": 1,
  "userDataList": [
    {
      "userId": 1,
      "firstName": null,
      "lastName": null
    }
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|branchName|string|false|none|none|
|address1|string¦null|false|none|none|
|address2|string¦null|false|none|none|
|address3|string¦null|false|none|none|
|contact|string¦null|false|none|none|
|email|string¦null|false|none|none|
|status|string|false|none|none|
|currencyID_FK|integer(int32)¦null|false|none|none|
|userId|integer(int32)|false|none|none|
|userDataList|[[C4WX1APIFeaturesBranchDtosBranchUserDto](#schemac4wx1apifeaturesbranchdtosbranchuserdto)]|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesBranchDtosBranchUserDto">C4WX1APIFeaturesBranchDtosBranchUserDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesbranchdtosbranchuserdto"></a>
<a id="schema_C4WX1APIFeaturesBranchDtosBranchUserDto"></a>
<a id="tocSc4wx1apifeaturesbranchdtosbranchuserdto"></a>
<a id="tocsc4wx1apifeaturesbranchdtosbranchuserdto"></a>

```json
{
  "userId": 0,
  "firstName": "string",
  "lastName": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|userId|integer(int32)|false|none|none|
|firstName|string|false|none|none|
|lastName|string|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesBranchDtosBranchDto">C4WX1APIFeaturesBranchDtosBranchDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesbranchdtosbranchdto"></a>
<a id="schema_C4WX1APIFeaturesBranchDtosBranchDto"></a>
<a id="tocSc4wx1apifeaturesbranchdtosbranchdto"></a>
<a id="tocsc4wx1apifeaturesbranchdtosbranchdto"></a>

```json
{
  "branchID": 0,
  "branchName": "string",
  "address1": "string",
  "address2": "string",
  "address3": "string",
  "contact": "string",
  "email": "string",
  "status": "string",
  "isSystemUsed": true,
  "currencyID_FK": 0,
  "currencyName": "string",
  "canDelete": true,
  "userDataList": [
    {
      "userId": 0,
      "firstName": "string",
      "lastName": "string"
    }
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|branchID|integer(int32)|false|none|none|
|branchName|string|false|none|none|
|address1|string¦null|false|none|none|
|address2|string¦null|false|none|none|
|address3|string¦null|false|none|none|
|contact|string¦null|false|none|none|
|email|string¦null|false|none|none|
|status|string|false|none|none|
|isSystemUsed|boolean|false|none|none|
|currencyID_FK|integer(int32)¦null|false|none|none|
|currencyName|string|false|none|none|
|canDelete|boolean|false|none|none|
|userDataList|[[C4WX1APIFeaturesBranchDtosBranchUserDto](#schemac4wx1apifeaturesbranchdtosbranchuserdto)]|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesBranchDtosDeleteBranchDto">C4WX1APIFeaturesBranchDtosDeleteBranchDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesbranchdtosdeletebranchdto"></a>
<a id="schema_C4WX1APIFeaturesBranchDtosDeleteBranchDto"></a>
<a id="tocSc4wx1apifeaturesbranchdtosdeletebranchdto"></a>
<a id="tocsc4wx1apifeaturesbranchdtosdeletebranchdto"></a>

```json
{
  "userId": 1
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|userId|integer(int32)|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesBranchDtosCreateBranchDto">C4WX1APIFeaturesBranchDtosCreateBranchDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesbranchdtoscreatebranchdto"></a>
<a id="schema_C4WX1APIFeaturesBranchDtosCreateBranchDto"></a>
<a id="tocSc4wx1apifeaturesbranchdtoscreatebranchdto"></a>
<a id="tocsc4wx1apifeaturesbranchdtoscreatebranchdto"></a>

```json
{
  "branchID": 0,
  "branchName": "BranchName",
  "address1": "Address1",
  "address2": "Address2",
  "address3": "Address3",
  "contact": "Contact",
  "email": "test@test.com",
  "status": "Active",
  "currencyID_FK": 1,
  "userId": 1,
  "userDataList": [
    {
      "userId": 1,
      "firstName": null,
      "lastName": null
    }
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|branchID|integer(int32)|false|none|none|
|branchName|string|false|none|none|
|address1|string¦null|false|none|none|
|address2|string¦null|false|none|none|
|address3|string¦null|false|none|none|
|contact|string¦null|false|none|none|
|email|string¦null|false|none|none|
|status|string|false|none|none|
|currencyID_FK|integer(int32)¦null|false|none|none|
|userId|integer(int32)|false|none|none|
|userDataList|[[C4WX1APIFeaturesBranchDtosBranchUserDto](#schemac4wx1apifeaturesbranchdtosbranchuserdto)]|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesBillingProposalDtosUpdateBillingProposalDto">C4WX1APIFeaturesBillingProposalDtosUpdateBillingProposalDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesbillingproposaldtosupdatebillingproposaldto"></a>
<a id="schema_C4WX1APIFeaturesBillingProposalDtosUpdateBillingProposalDto"></a>
<a id="tocSc4wx1apifeaturesbillingproposaldtosupdatebillingproposaldto"></a>
<a id="tocsc4wx1apifeaturesbillingproposaldtosupdatebillingproposaldto"></a>

```json
{
  "patientID_FK": 1,
  "title": "Title",
  "sendEmail": true,
  "emailPatient": true,
  "emailTo": "test-to@gmail.com",
  "emailCC": "test-cc@gmail.com",
  "emailBCC": "test-bcc@gmail.com",
  "currencyID_FK": 1,
  "status": "Active",
  "groupNumber": "1",
  "version": 1,
  "proposalType": "ProposalType",
  "userId": 1,
  "serviceList": [
    {
      "billingInvoiceServiceID": 0,
      "billingProposalID_FK": 0,
      "serviceID_FK": 1,
      "categoryId": 0,
      "title": null,
      "startDate": "2025-02-21T20:43:16.8101995+08:00",
      "endDate": "2025-02-21T20:43:16.8124593+08:00",
      "unitCost": 0,
      "duration1": "Duration1",
      "duration2": "Duration2",
      "visit": 1,
      "session": 0,
      "discount": 0,
      "serviceDescription": "ServiceDescription",
      "categoryName": null
    }
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|patientID_FK|integer(int32)|false|none|none|
|title|string|false|none|none|
|sendEmail|boolean¦null|false|none|none|
|emailPatient|boolean¦null|false|none|none|
|emailTo|string¦null|false|none|none|
|emailCC|string¦null|false|none|none|
|emailBCC|string¦null|false|none|none|
|currencyID_FK|integer(int32)|false|none|none|
|status|string|false|none|none|
|groupNumber|string|false|none|none|
|version|integer|false|none|none|
|proposalType|string|false|none|none|
|userId|integer(int32)|false|none|none|
|serviceList|[[C4WX1APIFeaturesBillingProposalDtosBillingProposalServiceDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposalservicedto)]|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesBillingProposalDtosBillingProposalServiceDto">C4WX1APIFeaturesBillingProposalDtosBillingProposalServiceDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesbillingproposaldtosbillingproposalservicedto"></a>
<a id="schema_C4WX1APIFeaturesBillingProposalDtosBillingProposalServiceDto"></a>
<a id="tocSc4wx1apifeaturesbillingproposaldtosbillingproposalservicedto"></a>
<a id="tocsc4wx1apifeaturesbillingproposaldtosbillingproposalservicedto"></a>

```json
{
  "billingInvoiceServiceID": 0,
  "billingProposalID_FK": 0,
  "serviceID_FK": 0,
  "categoryId": 0,
  "title": "string",
  "startDate": "2019-08-24T14:15:22Z",
  "endDate": "2019-08-24T14:15:22Z",
  "unitCost": 0,
  "duration1": "string",
  "duration2": "string",
  "visit": 0,
  "session": 0,
  "discount": 0,
  "serviceDescription": "string",
  "categoryName": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|billingInvoiceServiceID|integer(int32)|false|none|none|
|billingProposalID_FK|integer(int32)|false|none|none|
|serviceID_FK|integer(int32)|false|none|none|
|categoryId|integer(int32)|false|none|none|
|title|string|false|none|none|
|startDate|string(date-time)|false|none|none|
|endDate|string(date-time)|false|none|none|
|unitCost|number(decimal)|false|none|none|
|duration1|string¦null|false|none|none|
|duration2|string¦null|false|none|none|
|visit|integer(int32)|false|none|none|
|session|integer(int32)|false|none|none|
|discount|number(decimal)|false|none|none|
|serviceDescription|string¦null|false|none|none|
|categoryName|string|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesBillingProposalDtosUpdateBillingProposalStatusDto">C4WX1APIFeaturesBillingProposalDtosUpdateBillingProposalStatusDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesbillingproposaldtosupdatebillingproposalstatusdto"></a>
<a id="schema_C4WX1APIFeaturesBillingProposalDtosUpdateBillingProposalStatusDto"></a>
<a id="tocSc4wx1apifeaturesbillingproposaldtosupdatebillingproposalstatusdto"></a>
<a id="tocsc4wx1apifeaturesbillingproposaldtosupdatebillingproposalstatusdto"></a>

```json
{
  "userId": 1,
  "status": "Success"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|userId|integer(int32)|false|none|none|
|status|string|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesBillingProposalDtosBillingProposalDto">C4WX1APIFeaturesBillingProposalDtosBillingProposalDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesbillingproposaldtosbillingproposaldto"></a>
<a id="schema_C4WX1APIFeaturesBillingProposalDtosBillingProposalDto"></a>
<a id="tocSc4wx1apifeaturesbillingproposaldtosbillingproposaldto"></a>
<a id="tocsc4wx1apifeaturesbillingproposaldtosbillingproposaldto"></a>

```json
{
  "billingProposalID": 0,
  "patientID_FK": 0,
  "proposalNumber": "string",
  "title": "string",
  "sendEmail": true,
  "emailPatient": true,
  "emailTo": "string",
  "emailCC": "string",
  "emailBCC": "string",
  "currencyID_FK": 0,
  "currencyCode": "string",
  "totalCost": 0,
  "status": "string",
  "groupNumber": "string",
  "version": 0,
  "createdDate": "2019-08-24T14:15:22Z",
  "createdBy_FK": 0,
  "modifiedDate": "2019-08-24T14:15:22Z",
  "modifiedBy_FK": 0,
  "isDeleted": true,
  "proposalType": "string",
  "patientData": {
    "patientID": 0,
    "firstName": "string",
    "lastName": "string",
    "photo": "string",
    "mailingAddress1": "string",
    "mailingAddress2": "string",
    "mailingAddress3": "string",
    "mailingPostalCode": "string",
    "profile": {
      "email": "string"
    }
  },
  "createdByData": {
    "userId": 0,
    "firstName": "string",
    "lastName": "string",
    "photo": "string",
    "email": "string"
  },
  "modifiedByData": {
    "userId": 0,
    "firstName": "string",
    "lastName": "string",
    "photo": "string",
    "email": "string"
  },
  "serviceList": [
    {
      "billingInvoiceServiceID": 0,
      "billingProposalID_FK": 0,
      "serviceID_FK": 0,
      "categoryId": 0,
      "title": "string",
      "startDate": "2019-08-24T14:15:22Z",
      "endDate": "2019-08-24T14:15:22Z",
      "unitCost": 0,
      "duration1": "string",
      "duration2": "string",
      "visit": 0,
      "session": 0,
      "discount": 0,
      "serviceDescription": "string",
      "categoryName": "string"
    }
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|billingProposalID|integer(int32)|false|none|none|
|patientID_FK|integer(int32)|false|none|none|
|proposalNumber|string|false|none|none|
|title|string|false|none|none|
|sendEmail|boolean¦null|false|none|none|
|emailPatient|boolean¦null|false|none|none|
|emailTo|string¦null|false|none|none|
|emailCC|string¦null|false|none|none|
|emailBCC|string¦null|false|none|none|
|currencyID_FK|integer(int32)|false|none|none|
|currencyCode|string|false|none|none|
|totalCost|number(decimal)|false|none|none|
|status|string|false|none|none|
|groupNumber|string|false|none|none|
|version|integer|false|none|none|
|createdDate|string(date-time)|false|none|none|
|createdBy_FK|integer(int32)|false|none|none|
|modifiedDate|string(date-time)¦null|false|none|none|
|modifiedBy_FK|integer(int32)¦null|false|none|none|
|isDeleted|boolean|false|none|none|
|proposalType|string|false|none|none|
|patientData|[C4WX1APIFeaturesBillingProposalDtosBillingProposalPatientDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposalpatientdto)|false|none|none|
|createdByData|[C4WX1APIFeaturesBillingProposalDtosBillingProposalUserDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposaluserdto)|false|none|none|
|modifiedByData|[C4WX1APIFeaturesBillingProposalDtosBillingProposalUserDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposaluserdto)¦null|false|none|none|
|serviceList|[[C4WX1APIFeaturesBillingProposalDtosBillingProposalServiceDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposalservicedto)]|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesBillingProposalDtosBillingProposalPatientDto">C4WX1APIFeaturesBillingProposalDtosBillingProposalPatientDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesbillingproposaldtosbillingproposalpatientdto"></a>
<a id="schema_C4WX1APIFeaturesBillingProposalDtosBillingProposalPatientDto"></a>
<a id="tocSc4wx1apifeaturesbillingproposaldtosbillingproposalpatientdto"></a>
<a id="tocsc4wx1apifeaturesbillingproposaldtosbillingproposalpatientdto"></a>

```json
{
  "patientID": 0,
  "firstName": "string",
  "lastName": "string",
  "photo": "string",
  "mailingAddress1": "string",
  "mailingAddress2": "string",
  "mailingAddress3": "string",
  "mailingPostalCode": "string",
  "profile": {
    "email": "string"
  }
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|patientID|integer(int32)|false|none|none|
|firstName|string|false|none|none|
|lastName|string|false|none|none|
|photo|string¦null|false|none|none|
|mailingAddress1|string¦null|false|none|none|
|mailingAddress2|string¦null|false|none|none|
|mailingAddress3|string¦null|false|none|none|
|mailingPostalCode|string¦null|false|none|none|
|profile|[C4WX1APIFeaturesBillingProposalDtosBillingProposalPatientProfileDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposalpatientprofiledto)¦null|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesBillingProposalDtosBillingProposalPatientProfileDto">C4WX1APIFeaturesBillingProposalDtosBillingProposalPatientProfileDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesbillingproposaldtosbillingproposalpatientprofiledto"></a>
<a id="schema_C4WX1APIFeaturesBillingProposalDtosBillingProposalPatientProfileDto"></a>
<a id="tocSc4wx1apifeaturesbillingproposaldtosbillingproposalpatientprofiledto"></a>
<a id="tocsc4wx1apifeaturesbillingproposaldtosbillingproposalpatientprofiledto"></a>

```json
{
  "email": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|email|string¦null|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesBillingProposalDtosBillingProposalUserDto">C4WX1APIFeaturesBillingProposalDtosBillingProposalUserDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesbillingproposaldtosbillingproposaluserdto"></a>
<a id="schema_C4WX1APIFeaturesBillingProposalDtosBillingProposalUserDto"></a>
<a id="tocSc4wx1apifeaturesbillingproposaldtosbillingproposaluserdto"></a>
<a id="tocsc4wx1apifeaturesbillingproposaldtosbillingproposaluserdto"></a>

```json
{
  "userId": 0,
  "firstName": "string",
  "lastName": "string",
  "photo": "string",
  "email": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|userId|integer(int32)|false|none|none|
|firstName|string|false|none|none|
|lastName|string|false|none|none|
|photo|string¦null|false|none|none|
|email|string|false|none|none|

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
  "userId": 1
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|userId|integer(int32)|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesBillingProposalDtosCreateBillingProposalDto">C4WX1APIFeaturesBillingProposalDtosCreateBillingProposalDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesbillingproposaldtoscreatebillingproposaldto"></a>
<a id="schema_C4WX1APIFeaturesBillingProposalDtosCreateBillingProposalDto"></a>
<a id="tocSc4wx1apifeaturesbillingproposaldtoscreatebillingproposaldto"></a>
<a id="tocsc4wx1apifeaturesbillingproposaldtoscreatebillingproposaldto"></a>

```json
{
  "patientID_FK": 1,
  "title": "Title",
  "sendEmail": true,
  "emailPatient": true,
  "emailTo": "test-to@gmail.com",
  "emailCC": "test-cc@gmail.com",
  "emailBCC": "test-bcc@gmail.com",
  "currencyID_FK": 1,
  "status": "Active",
  "groupNumber": "1",
  "version": 1,
  "proposalType": "ProposalType",
  "userId": 1,
  "serviceList": [
    {
      "billingInvoiceServiceID": 0,
      "billingProposalID_FK": 0,
      "serviceID_FK": 1,
      "categoryId": 0,
      "title": null,
      "startDate": "2025-02-21T20:43:16.8364914+08:00",
      "endDate": "2025-02-21T20:43:16.8364935+08:00",
      "unitCost": 0,
      "duration1": "Duration1",
      "duration2": "Duration2",
      "visit": 1,
      "session": 0,
      "discount": 0,
      "serviceDescription": "ServiceDescription",
      "categoryName": null
    }
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|patientID_FK|integer(int32)|false|none|none|
|title|string|false|none|none|
|sendEmail|boolean¦null|false|none|none|
|emailPatient|boolean¦null|false|none|none|
|emailTo|string¦null|false|none|none|
|emailCC|string¦null|false|none|none|
|emailBCC|string¦null|false|none|none|
|currencyID_FK|integer(int32)|false|none|none|
|status|string|false|none|none|
|groupNumber|string|false|none|none|
|version|integer|false|none|none|
|proposalType|string|false|none|none|
|userId|integer(int32)|false|none|none|
|serviceList|[[C4WX1APIFeaturesBillingProposalDtosBillingProposalServiceDto](#schemac4wx1apifeaturesbillingproposaldtosbillingproposalservicedto)]|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesBillingInvoiceDtosBillingInvoiceDto">C4WX1APIFeaturesBillingInvoiceDtosBillingInvoiceDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesbillinginvoicedtosbillinginvoicedto"></a>
<a id="schema_C4WX1APIFeaturesBillingInvoiceDtosBillingInvoiceDto"></a>
<a id="tocSc4wx1apifeaturesbillinginvoicedtosbillinginvoicedto"></a>
<a id="tocsc4wx1apifeaturesbillinginvoicedtosbillinginvoicedto"></a>

```json
{
  "billingInvoiceID": 0,
  "patientID_FK": 0,
  "invoiceNumber": "string",
  "invoiceDueDate": "2019-08-24T14:15:22Z",
  "caseNumber": "string",
  "initialCareAssessmentID_FK": 0,
  "careReportID_FK": 0,
  "consumable": true,
  "sendEmail": true,
  "emailPatient": true,
  "emailTo": "string",
  "emailCC": "string",
  "emailBCC": "string",
  "currencyID_FK": 0,
  "totalCost": 0,
  "status": "string",
  "groupNumber": "string",
  "version": 0,
  "createdDate": "2019-08-24T14:15:22Z",
  "createdBy_FK": 0,
  "modifiedDate": "2019-08-24T14:15:22Z",
  "modifiedBy_FK": 0,
  "isDeleted": true,
  "invoiceDate": "2019-08-24T14:15:22Z",
  "currencyCode": "string",
  "patientData": {
    "patientID": 0,
    "firstName": "string",
    "lastName": "string",
    "photo": "string",
    "caseID": "string",
    "profile": {
      "email": "string",
      "billingAddress1": "string",
      "billingAddress2": "string",
      "billingAddress3": "string",
      "billingPostalCode": "string"
    }
  },
  "createdByData": {
    "userId": 0,
    "firstName": "string",
    "lastName": "string",
    "photo": "string",
    "email": "string"
  },
  "modifiedByData": {
    "userId": 0,
    "firstName": "string",
    "lastName": "string",
    "photo": "string",
    "email": "string"
  },
  "serviceList": [
    {
      "billingInvoiceServiceID": 0,
      "proposalID_FK": 0,
      "serviceID_FK": 0,
      "unitCost": 0,
      "session": 0,
      "discount": 0,
      "title": "string",
      "categoryName": "string",
      "billingProposalData": {
        "billingProposalID": 0,
        "proposalNumber": "string",
        "patientID_FK": 0,
        "title": "string",
        "proposalType": "string"
      }
    }
  ],
  "consumableList": [
    {
      "billingInvoiceConsumableID": 0,
      "itemID_FK": 0,
      "unitPrice": 0,
      "quantity": 0,
      "billingInvoiceItemDto": {
        "itemID": 0,
        "categoryID_FK": 0,
        "categoryName": "string",
        "itemName": "string"
      }
    }
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|billingInvoiceID|integer(int32)|false|none|none|
|patientID_FK|integer(int32)|false|none|none|
|invoiceNumber|string|false|none|none|
|invoiceDueDate|string(date-time)¦null|false|none|none|
|caseNumber|string¦null|false|none|none|
|initialCareAssessmentID_FK|integer(int32)¦null|false|none|none|
|careReportID_FK|integer(int32)¦null|false|none|none|
|consumable|boolean¦null|false|none|none|
|sendEmail|boolean¦null|false|none|none|
|emailPatient|boolean¦null|false|none|none|
|emailTo|string¦null|false|none|none|
|emailCC|string¦null|false|none|none|
|emailBCC|string¦null|false|none|none|
|currencyID_FK|integer(int32)|false|none|none|
|totalCost|number(decimal)|false|none|none|
|status|string|false|none|none|
|groupNumber|string|false|none|none|
|version|integer|false|none|none|
|createdDate|string(date-time)|false|none|none|
|createdBy_FK|integer(int32)|false|none|none|
|modifiedDate|string(date-time)¦null|false|none|none|
|modifiedBy_FK|integer(int32)¦null|false|none|none|
|isDeleted|boolean|false|none|none|
|invoiceDate|string(date-time)¦null|false|none|none|
|currencyCode|string|false|none|none|
|patientData|[C4WX1APIFeaturesBillingInvoiceDtosBillingInvoicePatientDto](#schemac4wx1apifeaturesbillinginvoicedtosbillinginvoicepatientdto)|false|none|none|
|createdByData|[C4WX1APIFeaturesBillingInvoiceDtosBillingInvoiceUserDto](#schemac4wx1apifeaturesbillinginvoicedtosbillinginvoiceuserdto)|false|none|none|
|modifiedByData|[C4WX1APIFeaturesBillingInvoiceDtosBillingInvoiceUserDto](#schemac4wx1apifeaturesbillinginvoicedtosbillinginvoiceuserdto)¦null|false|none|none|
|serviceList|[[C4WX1APIFeaturesBillingInvoiceDtosBillingInvoiceServiceDto](#schemac4wx1apifeaturesbillinginvoicedtosbillinginvoiceservicedto)]|false|none|none|
|consumableList|[[C4WX1APIFeaturesBillingInvoiceDtosBillingInvoiceConsumableDto](#schemac4wx1apifeaturesbillinginvoicedtosbillinginvoiceconsumabledto)]|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesBillingInvoiceDtosBillingInvoicePatientDto">C4WX1APIFeaturesBillingInvoiceDtosBillingInvoicePatientDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesbillinginvoicedtosbillinginvoicepatientdto"></a>
<a id="schema_C4WX1APIFeaturesBillingInvoiceDtosBillingInvoicePatientDto"></a>
<a id="tocSc4wx1apifeaturesbillinginvoicedtosbillinginvoicepatientdto"></a>
<a id="tocsc4wx1apifeaturesbillinginvoicedtosbillinginvoicepatientdto"></a>

```json
{
  "patientID": 0,
  "firstName": "string",
  "lastName": "string",
  "photo": "string",
  "caseID": "string",
  "profile": {
    "email": "string",
    "billingAddress1": "string",
    "billingAddress2": "string",
    "billingAddress3": "string",
    "billingPostalCode": "string"
  }
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|patientID|integer(int32)|false|none|none|
|firstName|string|false|none|none|
|lastName|string|false|none|none|
|photo|string¦null|false|none|none|
|caseID|string¦null|false|none|none|
|profile|[C4WX1APIFeaturesBillingInvoiceDtosBillingInvoicePatientProfileDto](#schemac4wx1apifeaturesbillinginvoicedtosbillinginvoicepatientprofiledto)¦null|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesBillingInvoiceDtosBillingInvoicePatientProfileDto">C4WX1APIFeaturesBillingInvoiceDtosBillingInvoicePatientProfileDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesbillinginvoicedtosbillinginvoicepatientprofiledto"></a>
<a id="schema_C4WX1APIFeaturesBillingInvoiceDtosBillingInvoicePatientProfileDto"></a>
<a id="tocSc4wx1apifeaturesbillinginvoicedtosbillinginvoicepatientprofiledto"></a>
<a id="tocsc4wx1apifeaturesbillinginvoicedtosbillinginvoicepatientprofiledto"></a>

```json
{
  "email": "string",
  "billingAddress1": "string",
  "billingAddress2": "string",
  "billingAddress3": "string",
  "billingPostalCode": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|email|string¦null|false|none|none|
|billingAddress1|string¦null|false|none|none|
|billingAddress2|string¦null|false|none|none|
|billingAddress3|string¦null|false|none|none|
|billingPostalCode|string¦null|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesBillingInvoiceDtosBillingInvoiceUserDto">C4WX1APIFeaturesBillingInvoiceDtosBillingInvoiceUserDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesbillinginvoicedtosbillinginvoiceuserdto"></a>
<a id="schema_C4WX1APIFeaturesBillingInvoiceDtosBillingInvoiceUserDto"></a>
<a id="tocSc4wx1apifeaturesbillinginvoicedtosbillinginvoiceuserdto"></a>
<a id="tocsc4wx1apifeaturesbillinginvoicedtosbillinginvoiceuserdto"></a>

```json
{
  "userId": 0,
  "firstName": "string",
  "lastName": "string",
  "photo": "string",
  "email": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|userId|integer(int32)|false|none|none|
|firstName|string|false|none|none|
|lastName|string|false|none|none|
|photo|string¦null|false|none|none|
|email|string|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesBillingInvoiceDtosBillingInvoiceServiceDto">C4WX1APIFeaturesBillingInvoiceDtosBillingInvoiceServiceDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesbillinginvoicedtosbillinginvoiceservicedto"></a>
<a id="schema_C4WX1APIFeaturesBillingInvoiceDtosBillingInvoiceServiceDto"></a>
<a id="tocSc4wx1apifeaturesbillinginvoicedtosbillinginvoiceservicedto"></a>
<a id="tocsc4wx1apifeaturesbillinginvoicedtosbillinginvoiceservicedto"></a>

```json
{
  "billingInvoiceServiceID": 0,
  "proposalID_FK": 0,
  "serviceID_FK": 0,
  "unitCost": 0,
  "session": 0,
  "discount": 0,
  "title": "string",
  "categoryName": "string",
  "billingProposalData": {
    "billingProposalID": 0,
    "proposalNumber": "string",
    "patientID_FK": 0,
    "title": "string",
    "proposalType": "string"
  }
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|billingInvoiceServiceID|integer(int32)|false|none|none|
|proposalID_FK|integer(int32)¦null|false|none|none|
|serviceID_FK|integer(int32)|false|none|none|
|unitCost|number(decimal)|false|none|none|
|session|integer(int32)|false|none|none|
|discount|number(decimal)|false|none|none|
|title|string|false|none|none|
|categoryName|string|false|none|none|
|billingProposalData|[C4WX1APIFeaturesBillingInvoiceDtosBillingInvoiceProposalDto](#schemac4wx1apifeaturesbillinginvoicedtosbillinginvoiceproposaldto)¦null|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesBillingInvoiceDtosBillingInvoiceProposalDto">C4WX1APIFeaturesBillingInvoiceDtosBillingInvoiceProposalDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesbillinginvoicedtosbillinginvoiceproposaldto"></a>
<a id="schema_C4WX1APIFeaturesBillingInvoiceDtosBillingInvoiceProposalDto"></a>
<a id="tocSc4wx1apifeaturesbillinginvoicedtosbillinginvoiceproposaldto"></a>
<a id="tocsc4wx1apifeaturesbillinginvoicedtosbillinginvoiceproposaldto"></a>

```json
{
  "billingProposalID": 0,
  "proposalNumber": "string",
  "patientID_FK": 0,
  "title": "string",
  "proposalType": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|billingProposalID|integer(int32)|false|none|none|
|proposalNumber|string|false|none|none|
|patientID_FK|integer(int32)|false|none|none|
|title|string|false|none|none|
|proposalType|string|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesBillingInvoiceDtosBillingInvoiceConsumableDto">C4WX1APIFeaturesBillingInvoiceDtosBillingInvoiceConsumableDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesbillinginvoicedtosbillinginvoiceconsumabledto"></a>
<a id="schema_C4WX1APIFeaturesBillingInvoiceDtosBillingInvoiceConsumableDto"></a>
<a id="tocSc4wx1apifeaturesbillinginvoicedtosbillinginvoiceconsumabledto"></a>
<a id="tocsc4wx1apifeaturesbillinginvoicedtosbillinginvoiceconsumabledto"></a>

```json
{
  "billingInvoiceConsumableID": 0,
  "itemID_FK": 0,
  "unitPrice": 0,
  "quantity": 0,
  "billingInvoiceItemDto": {
    "itemID": 0,
    "categoryID_FK": 0,
    "categoryName": "string",
    "itemName": "string"
  }
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|billingInvoiceConsumableID|integer(int32)|false|none|none|
|itemID_FK|integer(int32)|false|none|none|
|unitPrice|number(decimal)|false|none|none|
|quantity|integer(int32)|false|none|none|
|billingInvoiceItemDto|[C4WX1APIFeaturesBillingInvoiceDtosBillingInvoiceItemDto](#schemac4wx1apifeaturesbillinginvoicedtosbillinginvoiceitemdto)|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesBillingInvoiceDtosBillingInvoiceItemDto">C4WX1APIFeaturesBillingInvoiceDtosBillingInvoiceItemDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesbillinginvoicedtosbillinginvoiceitemdto"></a>
<a id="schema_C4WX1APIFeaturesBillingInvoiceDtosBillingInvoiceItemDto"></a>
<a id="tocSc4wx1apifeaturesbillinginvoicedtosbillinginvoiceitemdto"></a>
<a id="tocsc4wx1apifeaturesbillinginvoicedtosbillinginvoiceitemdto"></a>

```json
{
  "itemID": 0,
  "categoryID_FK": 0,
  "categoryName": "string",
  "itemName": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|itemID|integer(int32)|false|none|none|
|categoryID_FK|integer(int32)|false|none|none|
|categoryName|string|false|none|none|
|itemName|string|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesBillingInvoiceDtosGetBillingInvoiceDto">C4WX1APIFeaturesBillingInvoiceDtosGetBillingInvoiceDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesbillinginvoicedtosgetbillinginvoicedto"></a>
<a id="schema_C4WX1APIFeaturesBillingInvoiceDtosGetBillingInvoiceDto"></a>
<a id="tocSc4wx1apifeaturesbillinginvoicedtosgetbillinginvoicedto"></a>
<a id="tocsc4wx1apifeaturesbillinginvoicedtosgetbillinginvoicedto"></a>

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

<h2 id="tocS_C4WX1APIFeaturesAuditEnquiryDtosAuditEnquiryDto">C4WX1APIFeaturesAuditEnquiryDtosAuditEnquiryDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesauditenquirydtosauditenquirydto"></a>
<a id="schema_C4WX1APIFeaturesAuditEnquiryDtosAuditEnquiryDto"></a>
<a id="tocSc4wx1apifeaturesauditenquirydtosauditenquirydto"></a>
<a id="tocsc4wx1apifeaturesauditenquirydtosauditenquirydto"></a>

```json
{
  "auditAction": "string",
  "actionTime": "2019-08-24T14:15:22Z",
  "enquiryID": 0,
  "careManagerAssignedID_FK": 0,
  "enquirySourceID_FK": 0,
  "firstName": "string",
  "lastName": "string",
  "dateOfBirth": "2019-08-24T14:15:22Z",
  "raceID_FK": 0,
  "identificationNumber": "string",
  "preferredLanguageID_FK": 0,
  "genderID_FK": 0,
  "patientAddress1": "string",
  "patientAddress2": "string",
  "patientAddress3": "string",
  "postalCode": "string",
  "nameOfCaller": "string",
  "contactNumberOfCaller": "string",
  "emailOfCaller": "string",
  "preferredAppointmentDateTime": "2019-08-24T14:15:22Z",
  "medicalHistory": "string",
  "caregiverAtHomeID_FK": 0,
  "servicesRequiredID_FK": 0,
  "status": "string",
  "remarks": "string",
  "createdDate": "2019-08-24T14:15:22Z",
  "createdBy_FK": 0,
  "modifiedDate": "2019-08-24T14:15:22Z",
  "modifiedBy_FK": 0,
  "isDeleted": true,
  "otherRace": "string",
  "otherPreferredLanguage": "string",
  "userOrganizationID_FK": 0,
  "caseNumber": "string",
  "note": "string",
  "orderID": "string",
  "modifiedBy": {
    "userId": 0,
    "firstName": "string",
    "lastName": "string",
    "photo": "string"
  },
  "createdBy": {
    "userId": 0,
    "firstName": "string",
    "lastName": "string",
    "photo": "string"
  }
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|auditAction|string|false|none|none|
|actionTime|string(date-time)|false|none|none|
|enquiryID|integer(int32)|false|none|none|
|careManagerAssignedID_FK|integer(int32)¦null|false|none|none|
|enquirySourceID_FK|integer(int32)¦null|false|none|none|
|firstName|string¦null|false|none|none|
|lastName|string¦null|false|none|none|
|dateOfBirth|string(date-time)¦null|false|none|none|
|raceID_FK|integer(int32)¦null|false|none|none|
|identificationNumber|string¦null|false|none|none|
|preferredLanguageID_FK|integer(int32)¦null|false|none|none|
|genderID_FK|integer(int32)¦null|false|none|none|
|patientAddress1|string¦null|false|none|none|
|patientAddress2|string¦null|false|none|none|
|patientAddress3|string¦null|false|none|none|
|postalCode|string¦null|false|none|none|
|nameOfCaller|string¦null|false|none|none|
|contactNumberOfCaller|string¦null|false|none|none|
|emailOfCaller|string¦null|false|none|none|
|preferredAppointmentDateTime|string(date-time)¦null|false|none|none|
|medicalHistory|string¦null|false|none|none|
|caregiverAtHomeID_FK|integer(int32)¦null|false|none|none|
|servicesRequiredID_FK|integer(int32)¦null|false|none|none|
|status|string¦null|false|none|none|
|remarks|string¦null|false|none|none|
|createdDate|string(date-time)¦null|false|none|none|
|createdBy_FK|integer(int32)¦null|false|none|none|
|modifiedDate|string(date-time)¦null|false|none|none|
|modifiedBy_FK|integer(int32)¦null|false|none|none|
|isDeleted|boolean¦null|false|none|none|
|otherRace|string¦null|false|none|none|
|otherPreferredLanguage|string¦null|false|none|none|
|userOrganizationID_FK|integer(int32)¦null|false|none|none|
|caseNumber|string¦null|false|none|none|
|note|string¦null|false|none|none|
|orderID|string¦null|false|none|none|
|modifiedBy|[C4WX1APIFeaturesAuditEnquiryDtosAuditEnquiryUserDto](#schemac4wx1apifeaturesauditenquirydtosauditenquiryuserdto)¦null|false|none|none|
|createdBy|[C4WX1APIFeaturesAuditEnquiryDtosAuditEnquiryUserDto](#schemac4wx1apifeaturesauditenquirydtosauditenquiryuserdto)¦null|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesAuditEnquiryDtosAuditEnquiryUserDto">C4WX1APIFeaturesAuditEnquiryDtosAuditEnquiryUserDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesauditenquirydtosauditenquiryuserdto"></a>
<a id="schema_C4WX1APIFeaturesAuditEnquiryDtosAuditEnquiryUserDto"></a>
<a id="tocSc4wx1apifeaturesauditenquirydtosauditenquiryuserdto"></a>
<a id="tocsc4wx1apifeaturesauditenquirydtosauditenquiryuserdto"></a>

```json
{
  "userId": 0,
  "firstName": "string",
  "lastName": "string",
  "photo": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|userId|integer(int32)|false|none|none|
|firstName|string|false|none|none|
|lastName|string|false|none|none|
|photo|string¦null|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesAPIAccessKeyDtosAPIAccessKeyDto">C4WX1APIFeaturesAPIAccessKeyDtosAPIAccessKeyDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesapiaccesskeydtosapiaccesskeydto"></a>
<a id="schema_C4WX1APIFeaturesAPIAccessKeyDtosAPIAccessKeyDto"></a>
<a id="tocSc4wx1apifeaturesapiaccesskeydtosapiaccesskeydto"></a>
<a id="tocsc4wx1apifeaturesapiaccesskeydtosapiaccesskeydto"></a>

```json
{
  "apiAccessKeyID": 0,
  "tokenCode": "string",
  "accessKey": "string",
  "expiryDate": "2019-08-24T14:15:22Z",
  "createdDate": "2019-08-24T14:15:22Z",
  "updatedDate": "2019-08-24T14:15:22Z",
  "userId_FK": 0
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|apiAccessKeyID|integer(int32)|false|none|none|
|tokenCode|string|false|none|none|
|accessKey|string|false|none|none|
|expiryDate|string(date-time)|false|none|none|
|createdDate|string(date-time)|false|none|none|
|updatedDate|string(date-time)¦null|false|none|none|
|userId_FK|integer(int32)¦null|false|none|none|

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
  "code": "string",
  "userId": 0
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|code|string|false|none|none|
|userId|integer(int32)|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesActivityDtosUpdateActivityDto">C4WX1APIFeaturesActivityDtosUpdateActivityDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesactivitydtosupdateactivitydto"></a>
<a id="schema_C4WX1APIFeaturesActivityDtosUpdateActivityDto"></a>
<a id="tocSc4wx1apifeaturesactivitydtosupdateactivitydto"></a>
<a id="tocsc4wx1apifeaturesactivitydtosupdateactivitydto"></a>

```json
{
  "problemListID_FK": 1,
  "diseaseID_FK": 1,
  "activityDetail": "Activity Detail",
  "diseaseSubInfoID_FK": 1,
  "userId": 1
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|problemListID_FK|integer(int32)|false|none|none|
|diseaseID_FK|integer(int32)|false|none|none|
|activityDetail|string|false|none|none|
|diseaseSubInfoID_FK|integer(int32)¦null|false|none|none|
|userId|integer(int32)|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesActivityDtosActivityDto">C4WX1APIFeaturesActivityDtosActivityDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesactivitydtosactivitydto"></a>
<a id="schema_C4WX1APIFeaturesActivityDtosActivityDto"></a>
<a id="tocSc4wx1apifeaturesactivitydtosactivitydto"></a>
<a id="tocsc4wx1apifeaturesactivitydtosactivitydto"></a>

```json
{
  "activityID": 0,
  "problemListID_FK": 0,
  "diseaseID_FK": 0,
  "activityDetail": "string",
  "isDeleted": true,
  "createdDate": "2019-08-24T14:15:22Z",
  "createdBy_FK": 0,
  "modifiedDate": "2019-08-24T14:15:22Z",
  "modifiedBy_FK": 0,
  "diseaseSubInfoID_FK": 0,
  "canDelete": true
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|activityID|integer(int32)|false|none|none|
|problemListID_FK|integer(int32)|false|none|none|
|diseaseID_FK|integer(int32)|false|none|none|
|activityDetail|string|false|none|none|
|isDeleted|boolean|false|none|none|
|createdDate|string(date-time)¦null|false|none|none|
|createdBy_FK|integer(int32)¦null|false|none|none|
|modifiedDate|string(date-time)¦null|false|none|none|
|modifiedBy_FK|integer(int32)¦null|false|none|none|
|diseaseSubInfoID_FK|integer(int32)¦null|false|none|none|
|canDelete|boolean|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesActivityDtosDeleteActivityDto">C4WX1APIFeaturesActivityDtosDeleteActivityDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesactivitydtosdeleteactivitydto"></a>
<a id="schema_C4WX1APIFeaturesActivityDtosDeleteActivityDto"></a>
<a id="tocSc4wx1apifeaturesactivitydtosdeleteactivitydto"></a>
<a id="tocsc4wx1apifeaturesactivitydtosdeleteactivitydto"></a>

```json
{
  "userID": 1
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|userID|integer(int32)|false|none|none|

<h2 id="tocS_C4WX1APIFeaturesActivityDtosCreateActivityDto">C4WX1APIFeaturesActivityDtosCreateActivityDto</h2>
<!-- backwards compatibility -->
<a id="schemac4wx1apifeaturesactivitydtoscreateactivitydto"></a>
<a id="schema_C4WX1APIFeaturesActivityDtosCreateActivityDto"></a>
<a id="tocSc4wx1apifeaturesactivitydtoscreateactivitydto"></a>
<a id="tocsc4wx1apifeaturesactivitydtoscreateactivitydto"></a>

```json
{
  "problemListID_FK": 1,
  "diseaseID_FK": 1,
  "activityDetail": "Activity Detail",
  "diseaseSubInfoID_FK": 1,
  "userId": 1
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|problemListID_FK|integer(int32)|false|none|none|
|diseaseID_FK|integer(int32)|false|none|none|
|activityDetail|string|false|none|none|
|diseaseSubInfoID_FK|integer(int32)¦null|false|none|none|
|userId|integer(int32)|false|none|none|

