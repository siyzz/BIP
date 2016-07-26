package com.ccf.bip.framework.server.file;

import com.ccf.bip.framework.core.Globals;
import org.springframework.stereotype.Service;
import java.util.ArrayList;
import java.util.List;

/**
 * Created by siy on 2016/7/7.
 */
@Service("netFileService")
public class NetFileService implements INetFileService{
    private INetFileTransfer transfer;

    public NetFileService(){
        if(Globals.FILE_TRANSFER_MODE.equals("LOCAL")){
            transfer = new LocalNetFileTransfer();
        }
        else if(Globals.FILE_TRANSFER_MODE.equals("FTP")){
            transfer = new FtpNetFileTransfer();
        }
    }
    @Override
    public Integer upload(ArrayList<FileInfo> files) {
        return transfer.upload(files);
    }

    @Override
    public List<FileInfo> download(String fileName) {
        return transfer.download(fileName);
    }
}
