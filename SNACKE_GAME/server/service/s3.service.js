const s3 = require('aws-sdk/clients/s3');
const {AWS_S3_NAME, AWS_S3_REGION, AWS_S3_SECRET_KEY, AWS_S3_ACCESS_KEY} = require('../configs/config');

const bucket = new s3({
    region: AWS_S3_REGION,
    accessKeyId: AWS_S3_ACCESS_KEY,
    secretAccessKey: AWS_S3_SECRET_KEY
});

module.exports = {

}