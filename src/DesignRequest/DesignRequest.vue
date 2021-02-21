<script>
    import axios from 'axios'

    export default {
        name: "design-request",
        props: ['emailText', 'phoneText', 'headerText', 'paragraphOne', 'paragraphTwo', 'sizeText', 'productText', 'styleText', 'pictureText', 'textLabel', 'commentText', 'uploadText','thanksHeader','thanksText'],
        data() {
            return {
                complete:false,
                email: '',
                phone: '',
                size: '',
                selectedProduct: null,
                products: ['Akryl plade', 'Alu plader', 'Canvas / Lærred', 'Posters / Plakater', 'Tapet Glasvæv', 'Tapet Glat / Gips', 'Tapet Savsmuld', 'Wallsticker', 'Lærredsplade', 'Finérplade (træ)', 'Wallstickers tekst', 'Andet'],
                style: '',
                designPicture: null,
                text: '',
                pictures: null,
                comments: '',
                submitting: false,
                styleFile: null,
                ownFiles: [],
                phoneRules: [
                    v => !!v || 'Telefonnummer skal udfyldes',
                    v => v.length === 8 || 'Telefonnummer skal være 8 tegn'
                ],
                emailRules: [
                    v => !!v || 'E-mail skal udfyldes',
                    v => /.+@.+/.test(v) || 'E-mail er ikke korrekt udfyldt',
                    v => v.length < 100 || 'E-mail må maks være 100 tegn'
                ], sizeRules: [
                    v => !!v || 'Størrelse skal udfyldes',
                    v => v.length >= 6 || 'Skal være mindst 6 tegn eks. 40x30cm',
                    v => v.length <= 30 || 'Størrelse skal være under 30 tegn'
                ], commentRules: [
                    v => !!v || 'Kommentar skal udfyldes',
                    v => v.length > 10 || 'Skriv en længere kommentar',
                    v => v.length <= 2000 || 'Kommentaren skal være under 30 tegn'
                ],
                emailEmpty:false
            }
        },
        methods: {
            ownFileChanged(e) {
                this.ownFiles.push(this.$refs.ownFileRef.files[0]);
            },
            styleFileChanged(e) {
                this.styleFile = this.$refs.styleFileRef.files[0];
            },
            async submitForm(e) {
                if (this.checkForm()) {
                    let formData = new FormData();
                    formData.append("email", this.email.trim());
                    formData.append("phone", this.phone.trim());
                    formData.append("size", this.size.trim());
                    formData.append("product", this.selectedProduct);
                    if (this.style.length > 0)
                        formData.append("style", this.style);
                    if (this.text.length > 0)
                        formData.append("text", this.text);
                    formData.append("comments", this.comments.trim());
                    if(this.styleFile)
                        formData.append('styleFile', this.styleFile);
                    this.ownFiles.forEach(f => {
                        formData.append("ownFiles", f);
                    })

                    this.submitting = true;
                    await axios.post('/cms/umbraco/surface/DesignRequest/CreateDesignRequest', formData, {
                        headers: {
                            'Content-Type': 'multipart/formdata'
                        }
                    });
                    this.email = '';
                    this.phone = '';
                    this.size = '';
                    this.selectedProduct = null;

                    this.style = '';
                    this.designPicture = null;
                    this.text = '';
                    this.pictures = null;
                    this.comments = '';

                    this.styleFile = null;
                    this.ownFiles = [];
                    this.submitting = false;
                    this.complete = true;
                }
            },
            checkForm() {
                if(this.email.length == 0)
                    this.$refs.email.value = ' ';
                if(this.phone.length == 0)
                    this.$refs.phone.value = ' ';
                if(this.size.length == 0)
                    this.$refs.size.value = ' ';
                if(this.comments.length == 0)
                    this.$refs.comments.value = ' ';
                if (!/.+@.+/.test(this.email)) return false;
                if (this.phone.length < 8) return false;
                if (this.comments.length === 0) return false;
                return true;
            }


        }

    }

</script>
<template src="./DesignRequest.html"/>
<style src="./DesignRequest.scss"/>