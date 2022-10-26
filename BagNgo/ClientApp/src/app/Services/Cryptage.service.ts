import { Injectable } from '@angular/core';
import * as CryptoJS from 'crypto-js';

@Injectable({
  providedIn: 'root'
})
export class CryptageService {

constructor() { }
iv = CryptoJS.enc.Utf8.parse('7061737323313233');
secretKey = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c';

Encrypt(value: string): string {
  const key = CryptoJS.enc.Utf8.parse(this.secretKey);
  const iv = CryptoJS.enc.Utf8.parse(this.secretKey);
  const encrypted = CryptoJS.AES.encrypt(CryptoJS.enc.Utf8.parse(value.toString()), key,
    {
      keySize: 128 / 8,
      iv,
      mode: CryptoJS.mode.CBC,
      padding: CryptoJS.pad.Pkcs7
    });

  return encrypted.toString();
}

Decrypt(value: string): string {
  const key = CryptoJS.enc.Utf8.parse(this.secretKey);
  const iv = CryptoJS.enc.Utf8.parse(this.secretKey);
  const decrypted = CryptoJS.AES.decrypt(value, key, {
    keySize: 128 / 8,
    iv,
    mode: CryptoJS.mode.CBC,
    padding: CryptoJS.pad.Pkcs7
  });

  return decrypted.toString(CryptoJS.enc.Utf8);
  }
}

