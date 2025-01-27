export const HTTP_HEADERS = {
    AZURE_ASYNC_OPERATION: 'Azure-asyncoperation',
    CONTINUATION_TOKEN: 'x-ms-continuation',
    IF_MATCH: 'If-Match',
    LOCATION: 'Location',
    MAX_ITEM_COUNT: 'x-ms-max-item-count',
    RETRY_AFTER: 'Retry-After',
};
export const HTTP_ERROR_CODES = {
    BAD_REQUEST: 400,
    UNAUTHORIZED: 401,
    FORBIDDEN: 403,
    NOT_FOUND: 404,
    METHOD_NOT_SUPPORTED: 405,
    TIMEOUT: 408,
    CONFLICT: 409,
    PRECONDITION_FAILED: 412,
    PAYLOAD_TOO_LARGE: 413,
    TOO_MANY_REQUESTS: 429,
    CLIENT_CLOSED_REQUEST: 499,
    INTERNAL_SERVER_ERROR: 500,
    SERVICE_UNAVAILABLE: 503,
};
export const HTTP_ERROR_CODE_START = 300;
export const HTTP_SUCCESS_CODES = {
    OK: 200,
    ACCEPTED: 202,
};

export const HTTP_OPERATIONS = {
    DELETE: `DELETE`,
    GET: `GET`,
    PATCH: `PATCH`,
    POST: `POST`,
    PUT: `PUT`,
};

export const MIME_TYPES = {
    APPLICATION_JSON: 'application/json',
    APPLICATION_XML: 'application/xml',
    TEXT_PLAIN: 'text/plain',
};
