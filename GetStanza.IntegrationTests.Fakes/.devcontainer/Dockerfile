FROM mcr.microsoft.com/devcontainers/dotnet:1-8.0-bookworm


# [Optional] Uncomment this section to install additional OS packages.
# RUN apt-get update && export DEBIAN_FRONTEND=noninteractive \
#     && apt-get -y install --no-install-recommends <your-package-list-here>

COPY --from=mcr.microsoft.com/devcontainers/go:1.22-bookworm /usr/local/go/ /usr/local/go/
 
ENV PATH="/usr/local/go/bin:${PATH}"
ENV GOPATH /go
ENV PATH $GOPATH/bin:$PATH
RUN mkdir -p "$GOPATH/src" "$GOPATH/bin"
# Give vscode ownership of GOPATH
RUN chown -R vscode: /go

RUN go install github.com/fullstorydev/grpcurl/cmd/grpcurl@latest
RUN go install github.com/fullstorydev/grpcui/cmd/grpcui@latest

# [Optional] Uncomment this line to install global node packages.
# RUN su vscode -c "source /usr/local/share/nvm/nvm.sh && nvm install --lts && nvm use --lts && npm install -g typescript" 2>&1
# RUN su vscode -c "source /usr/local/share/nvm/nvm.sh && npm install -g <your-package-here>" 2>&1
