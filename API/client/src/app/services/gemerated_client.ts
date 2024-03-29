//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------

/* tslint:disable */
/* eslint-disable */
// ReSharper disable InconsistentNaming

export class MaterialClient {
    private http: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> };
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(baseUrl?: string, http?: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> }) {
        this.http = http ? http : window as any;
        this.baseUrl = baseUrl ?? "https://localhost:7247";
    }

    getAll(): Promise<Material[]> {
        let url_ = this.baseUrl + "/Material/GetAll";
        url_ = url_.replace(/[?&]$/, "");

        let options_: RequestInit = {
            method: "GET",
            headers: {
                "Accept": "application/json"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processGetAll(_response);
        });
    }

    protected processGetAll(response: Response): Promise<Material[]> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            if (Array.isArray(resultData200)) {
                result200 = [] as any;
                for (let item of resultData200)
                    result200!.push(Material.fromJS(item));
            }
            else {
                result200 = <any>null;
            }
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<Material[]>(null as any);
    }

    create(material: MaterialPostDTO): Promise<void> {
        let url_ = this.baseUrl + "/Material";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(material);

        let options_: RequestInit = {
            body: content_,
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processCreate(_response);
        });
    }

    protected processCreate(response: Response): Promise<void> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            return;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<void>(null as any);
    }

    update(material: Material): Promise<void> {
        let url_ = this.baseUrl + "/Material";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(material);

        let options_: RequestInit = {
            body: content_,
            method: "PUT",
            headers: {
                "Content-Type": "application/json",
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processUpdate(_response);
        });
    }

    protected processUpdate(response: Response): Promise<void> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            return;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<void>(null as any);
    }

    delete(id: string | undefined): Promise<void> {
        let url_ = this.baseUrl + "/Material?";
        if (id === null)
            throw new Error("The parameter 'id' cannot be null.");
        else if (id !== undefined)
            url_ += "id=" + encodeURIComponent("" + id) + "&";
        url_ = url_.replace(/[?&]$/, "");

        let options_: RequestInit = {
            method: "DELETE",
            headers: {
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processDelete(_response);
        });
    }

    protected processDelete(response: Response): Promise<void> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            return;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<void>(null as any);
    }
}

export class UserClient {
    private http: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> };
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(baseUrl?: string, http?: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> }) {
        this.http = http ? http : window as any;
        this.baseUrl = baseUrl ?? "https://localhost:7247";
    }

    login(loginUser: LoginDTO): Promise<LoginResponseDTO> {
        let url_ = this.baseUrl + "/User";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(loginUser);

        let options_: RequestInit = {
            body: content_,
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processLogin(_response);
        });
    }

    protected processLogin(response: Response): Promise<LoginResponseDTO> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = LoginResponseDTO.fromJS(resultData200);
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<LoginResponseDTO>(null as any);
    }

    register(userDTO: RegisterDTO): Promise<FileResponse> {
        let url_ = this.baseUrl + "/User/register";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(userDTO);

        let options_: RequestInit = {
            body: content_,
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/octet-stream"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processRegister(_response);
        });
    }

    protected processRegister(response: Response): Promise<FileResponse> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200 || status === 206) {
            const contentDisposition = response.headers ? response.headers.get("content-disposition") : undefined;
            let fileNameMatch = contentDisposition ? /filename\*=(?:(\\?['"])(.*?)\1|(?:[^\s]+'.*?')?([^;\n]*))/g.exec(contentDisposition) : undefined;
            let fileName = fileNameMatch && fileNameMatch.length > 1 ? fileNameMatch[3] || fileNameMatch[2] : undefined;
            if (fileName) {
                fileName = decodeURIComponent(fileName);
            } else {
                fileNameMatch = contentDisposition ? /filename="?([^"]*?)"?(;|$)/g.exec(contentDisposition) : undefined;
                fileName = fileNameMatch && fileNameMatch.length > 1 ? fileNameMatch[1] : undefined;
            }
            return response.blob().then(blob => { return { fileName: fileName, data: blob, status: status, headers: _headers }; });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<FileResponse>(null as any);
    }

    getRoles(): Promise<string[]> {
        let url_ = this.baseUrl + "/User/Roles";
        url_ = url_.replace(/[?&]$/, "");

        let options_: RequestInit = {
            method: "GET",
            headers: {
                "Accept": "application/json"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processGetRoles(_response);
        });
    }

    protected processGetRoles(response: Response): Promise<string[]> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            if (Array.isArray(resultData200)) {
                result200 = [] as any;
                for (let item of resultData200)
                    result200!.push(item);
            }
            else {
                result200 = <any>null;
            }
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<string[]>(null as any);
    }
}

export class Material implements IMaterial {
    id?: string;
    name!: string;
    fat?: number;
    protein?: number;
    kilocalorie?: number;
    kilojoule?: number;
    carbohydrate?: number;
    cholesterol?: number;
    saturatedfat?: number;
    transfat?: number;
    natrium_mg?: number;
    fluorite_mg?: number;
    salt?: number;
    sugar?: number;
    scale?: number;
    scaleType?: number;
    updated?: Date;
    updatedBy?: string;
    allergen?: boolean;

    constructor(data?: IMaterial) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.id = _data["id"];
            this.name = _data["name"];
            this.fat = _data["fat"];
            this.protein = _data["protein"];
            this.kilocalorie = _data["kilocalorie"];
            this.kilojoule = _data["kilojoule"];
            this.carbohydrate = _data["carbohydrate"];
            this.cholesterol = _data["cholesterol"];
            this.saturatedfat = _data["saturatedfat"];
            this.transfat = _data["transfat"];
            this.natrium_mg = _data["natrium_mg"];
            this.fluorite_mg = _data["fluorite_mg"];
            this.salt = _data["salt"];
            this.sugar = _data["sugar"];
            this.scale = _data["scale"];
            this.scaleType = _data["scaleType"];
            this.updated = _data["updated"] ? new Date(_data["updated"].toString()) : <any>undefined;
            this.updatedBy = _data["updatedBy"];
            this.allergen = _data["allergen"];
        }
    }

    static fromJS(data: any): Material {
        data = typeof data === 'object' ? data : {};
        let result = new Material();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["name"] = this.name;
        data["fat"] = this.fat;
        data["protein"] = this.protein;
        data["kilocalorie"] = this.kilocalorie;
        data["kilojoule"] = this.kilojoule;
        data["carbohydrate"] = this.carbohydrate;
        data["cholesterol"] = this.cholesterol;
        data["saturatedfat"] = this.saturatedfat;
        data["transfat"] = this.transfat;
        data["natrium_mg"] = this.natrium_mg;
        data["fluorite_mg"] = this.fluorite_mg;
        data["salt"] = this.salt;
        data["sugar"] = this.sugar;
        data["scale"] = this.scale;
        data["scaleType"] = this.scaleType;
        data["updated"] = this.updated ? this.updated.toISOString() : <any>undefined;
        data["updatedBy"] = this.updatedBy;
        data["allergen"] = this.allergen;
        return data;
    }
}

export interface IMaterial {
    id?: string;
    name: string;
    fat?: number;
    protein?: number;
    kilocalorie?: number;
    kilojoule?: number;
    carbohydrate?: number;
    cholesterol?: number;
    saturatedfat?: number;
    transfat?: number;
    natrium_mg?: number;
    fluorite_mg?: number;
    salt?: number;
    sugar?: number;
    scale?: number;
    scaleType?: number;
    updated?: Date;
    updatedBy?: string;
    allergen?: boolean;
}

export class MaterialPostDTO implements IMaterialPostDTO {
    name?: string;
    fat?: number;
    protein?: number;
    kilocalorie?: number;
    kilojoule?: number;
    carbohydrate?: number;
    cholesterol?: number;
    saturatedfat?: number;
    transfat?: number;
    natrium_mg?: number;
    fluorite_mg?: number;
    salt?: number;
    sugar?: number;
    scale?: number;
    updated?: Date;
    updatedBy?: string;

    constructor(data?: IMaterialPostDTO) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.name = _data["name"];
            this.fat = _data["fat"];
            this.protein = _data["protein"];
            this.kilocalorie = _data["kilocalorie"];
            this.kilojoule = _data["kilojoule"];
            this.carbohydrate = _data["carbohydrate"];
            this.cholesterol = _data["cholesterol"];
            this.saturatedfat = _data["saturatedfat"];
            this.transfat = _data["transfat"];
            this.natrium_mg = _data["natrium_mg"];
            this.fluorite_mg = _data["fluorite_mg"];
            this.salt = _data["salt"];
            this.sugar = _data["sugar"];
            this.scale = _data["scale"];
            this.updated = _data["updated"] ? new Date(_data["updated"].toString()) : <any>undefined;
            this.updatedBy = _data["updatedBy"];
        }
    }

    static fromJS(data: any): MaterialPostDTO {
        data = typeof data === 'object' ? data : {};
        let result = new MaterialPostDTO();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["name"] = this.name;
        data["fat"] = this.fat;
        data["protein"] = this.protein;
        data["kilocalorie"] = this.kilocalorie;
        data["kilojoule"] = this.kilojoule;
        data["carbohydrate"] = this.carbohydrate;
        data["cholesterol"] = this.cholesterol;
        data["saturatedfat"] = this.saturatedfat;
        data["transfat"] = this.transfat;
        data["natrium_mg"] = this.natrium_mg;
        data["fluorite_mg"] = this.fluorite_mg;
        data["salt"] = this.salt;
        data["sugar"] = this.sugar;
        data["scale"] = this.scale;
        data["updated"] = this.updated ? this.updated.toISOString() : <any>undefined;
        data["updatedBy"] = this.updatedBy;
        return data;
    }
}

export interface IMaterialPostDTO {
    name?: string;
    fat?: number;
    protein?: number;
    kilocalorie?: number;
    kilojoule?: number;
    carbohydrate?: number;
    cholesterol?: number;
    saturatedfat?: number;
    transfat?: number;
    natrium_mg?: number;
    fluorite_mg?: number;
    salt?: number;
    sugar?: number;
    scale?: number;
    updated?: Date;
    updatedBy?: string;
}

export class LoginResponseDTO implements ILoginResponseDTO {
    firstName?: string;
    lastName?: string;
    email?: string;
    role?: string;
    token?: string;

    constructor(data?: ILoginResponseDTO) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.firstName = _data["firstName"];
            this.lastName = _data["lastName"];
            this.email = _data["email"];
            this.role = _data["role"];
            this.token = _data["token"];
        }
    }

    static fromJS(data: any): LoginResponseDTO {
        data = typeof data === 'object' ? data : {};
        let result = new LoginResponseDTO();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["firstName"] = this.firstName;
        data["lastName"] = this.lastName;
        data["email"] = this.email;
        data["role"] = this.role;
        data["token"] = this.token;
        return data;
    }
}

export interface ILoginResponseDTO {
    firstName?: string;
    lastName?: string;
    email?: string;
    role?: string;
    token?: string;
}

export class LoginDTO implements ILoginDTO {
    email?: string;
    password?: string;

    constructor(data?: ILoginDTO) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.email = _data["email"];
            this.password = _data["password"];
        }
    }

    static fromJS(data: any): LoginDTO {
        data = typeof data === 'object' ? data : {};
        let result = new LoginDTO();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["email"] = this.email;
        data["password"] = this.password;
        return data;
    }
}

export interface ILoginDTO {
    email?: string;
    password?: string;
}

export class RegisterDTO implements IRegisterDTO {
    firstName?: string;
    lastName?: string;
    email?: string;
    password?: string;
    role?: string;

    constructor(data?: IRegisterDTO) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.firstName = _data["firstName"];
            this.lastName = _data["lastName"];
            this.email = _data["email"];
            this.password = _data["password"];
            this.role = _data["role"];
        }
    }

    static fromJS(data: any): RegisterDTO {
        data = typeof data === 'object' ? data : {};
        let result = new RegisterDTO();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["firstName"] = this.firstName;
        data["lastName"] = this.lastName;
        data["email"] = this.email;
        data["password"] = this.password;
        data["role"] = this.role;
        return data;
    }
}

export interface IRegisterDTO {
    firstName?: string;
    lastName?: string;
    email?: string;
    password?: string;
    role?: string;
}

export interface FileResponse {
    data: Blob;
    status: number;
    fileName?: string;
    headers?: { [name: string]: any };
}

export class ApiException extends Error {
    message: string;
    status: number;
    response: string;
    headers: { [key: string]: any; };
    result: any;

    constructor(message: string, status: number, response: string, headers: { [key: string]: any; }, result: any) {
        super();

        this.message = message;
        this.status = status;
        this.response = response;
        this.headers = headers;
        this.result = result;
    }

    protected isApiException = true;

    static isApiException(obj: any): obj is ApiException {
        return obj.isApiException === true;
    }
}

function throwException(message: string, status: number, response: string, headers: { [key: string]: any; }, result?: any): any {
    if (result !== null && result !== undefined)
        throw result;
    else
        throw new ApiException(message, status, response, headers, null);
}