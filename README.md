[![Project Status](http://opensource.box.com/badges/active.svg)](http://opensource.box.com/badges)

Extension library implementing IPluginClaimProvider interface to support custom scope and claims for integrated client application
==================================


> **Note**
> This library and customization project was used during Acumatica Dev Conference 2023 Day 2. This is not meant for production use as is.
>



* Purpose of this GitHub project is to show case how to make Acumatica as an Identity Provider (IdP) using OpenID Connect protocol.
* With this extension libray, you can support supplying addition information about user during Single Sign-on process as claims.

### Prerequisites
* Acumatica 2023 R1 (23.105.0016 or higher)

### Installation

##### Install customization deployment package
1. Download PXOIDCDemoExtPkg.zip.
2. In your Acumatica ERP/Portal instance, navigate to System -> Customization -> Customization Projects (SM204505), import PXOIDCDemoExtPkg.zip as a customization project
3. Publish customization project.

### Usage

Once package is published on Acumatica Instance,

1. New Connected Application is available on Connected Application Screen (SM303010)

![Screenshot](/_ReadMeImages/Image1-ConnectedApplication.png)

2. New fields for inSided Role and MindMatrix Role are available on User Roles screen (SM201005) 

![Screenshot](/_ReadMeImages/Image2-UserRole.png)

3. This connected application can be used in supplied Postman collection for demo purpose.

[Postman Collection](https://github.com/Acumatica/Acumatica-OIDCDemo/tree/main/Postman%20Collection)

Demonstration video is available at [2023 Acumatica Virtual Developer Conference - June 27 - 29](https://community.acumatica.com/other-developer-topics-290/2023-acumatica-virtual-developer-conference-june-27-29-17219) in Day 2 section.

Known Issues
------------
None at the moment

## Copyright and License

Copyright © `2023` `Acumatica, INC`

This component is licensed under the MIT License, a copy of which is available online [here](LICENSE)
